using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace EDOverlay {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private DispatcherTimer rotateTimer;
        private Stopwatch sw = Stopwatch.StartNew();

        public MainWindow() {
            InitializeComponent();
            rotateTimer = new DispatcherTimer {
                              Interval = new TimeSpan(0, 0, 0, 0, 20),
                              IsEnabled = true
                          };
            rotateTimer.Tick += RotateTimer_Tick;
        }

        private void RotateTimer_Tick(object sender, EventArgs e) {
            CubeModel.Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 1, 0), sw.Elapsed.TotalSeconds * 60));

            var scR = (float)(Math.Sin(sw.Elapsed.TotalSeconds) * 0.5);
            var scA = (float)(Math.Sin(sw.Elapsed.TotalSeconds * 1.55) * 0.5);
            DiffuseMain.Brush = new SolidColorBrush(new Color() { ScR = scR, ScA = scA});
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
            else if (e.RightButton == MouseButtonState.Pressed)
                CubeModel.Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), DateTime.Now.Ticks));
        }
    }
}
