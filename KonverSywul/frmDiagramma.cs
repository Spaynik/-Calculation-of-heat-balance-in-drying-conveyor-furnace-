using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using ZedGraph;

namespace KonverSywul
{
    public partial class frmDiagramma : Form
    {
        // Создать главный объект, который включает в себя все нужные объекты
        public MathClass.Class1 _c = new MathClass.Class1();

        public frmDiagramma() { }

        public frmDiagramma(MathClass.Class1 c)
        {
            _c = c;
            InitializeComponent();
            CenterToScreen();

            DrawGraph();
        }
        
        private void DrawGraph()
        {
            // Получим панель для рисования
            GraphPane pane = f.GraphPane;
                        
            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            //Количество параметров
            int itemscount = 4;
            
            // Подписи параметров
            string[] names = new string[itemscount];

            // Размер 
            double[] values = new double[itemscount];
            
            // Заполним данные
            for (int i = 0; i < itemscount; i++)
            {
                names[0] = string.Format("Q");
                names[1] = string.Format("Q2");
                names[2] = string.Format("Q3");
                names[3] = string.Format("Q4");
                values[0] = _c.Q1();
                values[1] = _c.QW();
                values[2] = _c.Q5W();
                values[3] = _c.Q5pn();
            }
            // Круговая диаграмма с выбором цвета
            pane.AddPieSlice(values[0], Color.Tan, 0F, names[0]);
            pane.AddPieSlice(values[1], Color.PeachPuff, 0F, names[1]);
            pane.AddPieSlice(values[2], Color.Peru, 0F, names[2]);
            pane.AddPieSlice(values[3], Color.NavajoWhite, 0F, names[3]);

            //pane.AddPieSlices(values, names); // цвет устанавливается автоматически
            pane.Legend.IsVisible = false;
            foreach (var x in pane.CurveList.OfType<PieItem>())
                x.LabelType = PieLabelType.Name_Percent;

            // Изменим текст заголовка графика
            pane.Title.Text = "Результат расчета теплового баланса конвейерной печи";

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            f.AxisChange();

            // Обновляем график
            f.Invalidate();
        }
        
        private void btn_Graf_Click_1(object sender, EventArgs e)
        {
            DrawGraph();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
