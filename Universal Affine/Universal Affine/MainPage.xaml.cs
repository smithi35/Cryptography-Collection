using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Universal_Affine
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Encode.Click += encode;
            Decode.Click += decode;
        }

        public void encode(Object o, RoutedEventArgs e)
        {
            try
            {
                int shift = int.Parse(Shift.Text);
                try
                {
                    int multiplier = int.Parse(Multiplier.Text);
                    string text = Content.Text;
                    Affine cipher = new Affine { Shift = shift, Multiplier = multiplier, Content = text };
                    Content.Text = cipher.Encode();
                }
                catch (FormatException exc)
                {
                    Multiplier.Text = exc.Message;
                }
            }
            catch (FormatException exc)
            {
                Shift.Text = exc.Message;
            }
        }

        public void decode(Object o, RoutedEventArgs e)
        {
            try
            {
                int shift = int.Parse(Shift.Text);
                try
                {
                    int multiplier = int.Parse(Multiplier.Text);
                    string text = Content.Text;
                    Affine cipher = new Affine { Shift = shift, Multiplier = multiplier, Content = text };
                    Content.Text = cipher.Decode();
                }
                catch (FormatException exc)
                {
                    Multiplier.Text = exc.Message;
                }
            }
            catch (FormatException exc)
            {
                Shift.Text = exc.Message;
            }
        }
    }
}
