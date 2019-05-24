using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiskCleanup.UserControls.DirSubTreeViewer
{
    /// <summary>
    /// Interaction logic for DirSubTreeViewer.xaml
    /// </summary>
    public partial class DirSubTreeViewer : UserControl
    {
        public DirSubTreeViewer()
        {
            InitializeComponent();
        }

        #region DependencyProperties
        public static readonly DependencyProperty RootDirSubTreeProperty =
             DependencyProperty.Register(
        "RootDirSubTree", typeof(string), typeof(TextBox),
        new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnTextChanged),
                                      new CoerceValueCallback(CoerceValue)));
        /// <summary>
        /// Gets or sets the value assigned to the control.
        /// </summary>
        public string Value
        {
            get { return (string)GetValue(RootDirSubTreeProperty); }
            set { SetValue(RootDirSubTreeProperty, value); }
        }

        private static object CoerceValue(DependencyObject element, object value)
        {
            string newValue = (string)value;
            TextBox control = (TextBox)element;

            //newValue = Math.Max(MinValue, Math.Min(MaxValue, newValue));

            return newValue;
        }

        private static void OnTextChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            TextBox control = (TextBox)obj;

            RoutedPropertyChangedEventArgs<string> e = new RoutedPropertyChangedEventArgs<string>(
                (string)args.OldValue, (string)args.NewValue, TextChangedEvent);
            control.OnTextChanged(e);
        }

        /// <summary>
        /// Identifies the TextChanged routed event.
        /// </summary>
        public static readonly RoutedEvent TextChangedEvent = EventManager.RegisterRoutedEvent(
            "TextChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<string>), typeof(TextBox));

        /// <summary>
        /// Occurs when the Value property changes.
        /// </summary>
        public event RoutedPropertyChangedEventHandler<string> TextChanged
        {
            add { AddHandler(TextChangedEvent, value); }
            remove { RemoveHandler(TextChangedEvent, value); }
        }

        /// <summary>
        /// Raises the ValueChanged event.
        /// </summary>
        /// <param name="args">Arguments associated with the ValueChanged event.</param>
        protected virtual void OnTextChanged(RoutedPropertyChangedEventArgs<string> args)
        {
            RaiseEvent(args);
        }
        #endregion //DependencyProperties
    }
}
