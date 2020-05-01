using System;
using Xamarin.Forms;

namespace CoordinatorLayout.XamarinForms
{
    public partial class CoordinatorLayout
    {
        /// <summary>
        /// Event that is raised when the top view expands or collapses. Argument values range from 0.0 (collapsed) to 1.0 (expanded).
        /// </summary>
        public event EventHandler<ExpansionEventArgs> ExpansionEventHandler;

        /// <summary>
        /// Event that is raised when the bottom view is scrolled. Argument values range from 0.0 (not scrolled) to 1.0 (fully scrolled).
        /// </summary>
        public event EventHandler<ScrollEventArgs> ScrollEventHandler;

        public static readonly BindableProperty ProportionalTopViewHeightMinProperty = BindableProperty.Create(
            nameof(ProportionalTopViewHeightMin),
            typeof(double),
            typeof(CoordinatorLayout),
            0.1d,
            coerceValue: (bindable, value) => Math.Max(0.0d, Math.Min((double) value, 1.0d))
        );

        /// <summary>
        /// The minimum height of the top view, as a proportion of the entire coordinator layout. Coerced to [0.0, 1.0] where 0.0 means that the top view can be collapsed completely and 1.0 means that the top view cannot be collapsed at all.
        /// </summary>
        public double ProportionalTopViewHeightMin
        {
            get => (double) GetValue(ProportionalTopViewHeightMinProperty);
            set => SetValue(ProportionalTopViewHeightMinProperty, value);
        }

        public static readonly BindableProperty ProportionalTopViewHeightMaxProperty = BindableProperty.Create(
            nameof(ProportionalTopViewHeightMax),
            typeof(double),
            typeof(CoordinatorLayout),
            0.5d,
            coerceValue: (bindable, value) => Math.Max(0.0d, Math.Min((double) value, 1.0d))
        );

        /// <summary>
        /// The maximum height of the top view, as a proportion of the entire coordinator layout. Coerced to [0.0, 1.0] where 0.0 means that the top view can be collapsed completely and 1.0 means that the top view cannot be collapsed at all.
        /// </summary>
        public double ProportionalTopViewHeightMax
        {
            get => (double) GetValue(ProportionalTopViewHeightMaxProperty);
            set => SetValue(ProportionalTopViewHeightMaxProperty, value);
        }

        public static readonly BindableProperty ProportionalSnapHeightProperty = BindableProperty.Create(
            nameof(ProportionalSnapHeight),
            typeof(double),
            typeof(CoordinatorLayout),
            0.5d,
            coerceValue: (bindable, value) => Math.Max(0.0d, Math.Min((double) value, 1.0d))
        );

        /// <summary>
        /// The top view snaps to its collapsed position while smaller than this value or it snaps to its expanded position while it is larger than this value.
        ///
        /// <para>Defaults to 0.5, i.e. half way</para>
        /// </summary>
        public double ProportionalSnapHeight
        {
            get => (double) GetValue(ProportionalSnapHeightProperty);
            set => SetValue(ProportionalSnapHeightProperty, value);
        }

        public static readonly BindableProperty TopViewProperty = BindableProperty.Create(
            nameof(TopView),
            typeof(View),
            typeof(CoordinatorLayout)
        );

        /// <summary>
        /// The view to show at the top of the coordinator layout. This view will be expanded and collapsed, according to the properties <see cref="ProportionalTopViewHeightMin"/> and <see cref="ProportionalTopViewHeightMax"/>
        ///
        /// <para>This property is mandatory</para>
        /// 
        /// </summary>
        public View TopView
        {
            get => (View) GetValue(TopViewProperty);
            set => SetValue(TopViewProperty, value);
        }

        public static readonly BindableProperty BottomViewProperty = BindableProperty.Create(
            nameof(BottomView),
            typeof(View),
            typeof(CoordinatorLayout)
        );

        /// <summary>
        /// The view to show at the bottom of the coordinator layout. This view will be scrolled vertically, in case that it doesn't fit in the available space, below the <see cref="TopView"/>
        ///
        /// <para>This property is mandatory</para>
        ///  
        /// </summary>
        public View BottomView
        {
            get => (View) GetValue(BottomViewProperty);
            set => SetValue(BottomViewProperty, value);
        }

        public static readonly BindableProperty ActionViewProperty = BindableProperty.Create(
            nameof(ActionView),
            typeof(View),
            typeof(CoordinatorLayout)
        );

        /// <summary>
        /// A view to be shown between the top view and bottom view. This view usually contains controls that trigger an action, e.g. a <see cref="Button"/>
        ///
        /// <para>This view is hosted in a container view which is by default 20% of the coordinator layout height. In case that the <see cref="ActionView"/> is not shown or is cut off, increase the container view's height by adjusting <see cref="ProportionalActionViewContainerHeight"/> </para>
        /// 
        /// <para>This property is optional</para>
        /// 
        /// </summary>
        public View ActionView
        {
            get => (View) GetValue(ActionViewProperty);
            set => SetValue(ActionViewProperty, value);
        }

        public static readonly BindableProperty ProportionalActionViewContainerHeightProperty = BindableProperty.Create(
            nameof(ProportionalActionViewContainerHeight),
            typeof(double),
            typeof(CoordinatorLayout),
            0.2d,
            coerceValue: (bindable, value) => Math.Max(0.0d, Math.Min((double) value, 1.0d))
        );

        /// <summary>
        ///  The proportional height of the <see cref="ActionView"/>'s container.
        /// </summary>
        public double ProportionalActionViewContainerHeight
        {
            get => (double) GetValue(ProportionalActionViewContainerHeightProperty);
            set => SetValue(ProportionalActionViewContainerHeightProperty, value);
        }
    }
}