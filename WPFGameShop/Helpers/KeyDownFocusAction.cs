using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace WPFGameShop
{
    public class KeyDownFocusAction : TriggerAction<UIElement>
    {
        public static readonly DependencyProperty KeyProperty =
            DependencyProperty.Register(nameof(Key), typeof(Key), typeof(KeyDownFocusAction));
        public Key Key
        {
            get => (Key)GetValue(KeyProperty);
            set => SetValue(KeyProperty, value);
        }

        public static readonly DependencyProperty CtrlProperty =
            DependencyProperty.Register(nameof(Ctrl), typeof(bool), typeof(KeyDownFocusAction));
        public bool Ctrl
        {
            get => (bool)GetValue(CtrlProperty);
            set => SetValue(CtrlProperty, value);
        }

        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register(nameof(Target), typeof(UIElement), typeof(KeyDownFocusAction), new UIPropertyMetadata(null));
        public UIElement Target
        {
            get => (UIElement)GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }

        protected override void Invoke(object parameter)
        {
            if (Keyboard.IsKeyDown(Key))
            {
                if (Ctrl == true)
                {
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    {
                        Target.Focus();
                    }
                }
            }
        }
    }
}
