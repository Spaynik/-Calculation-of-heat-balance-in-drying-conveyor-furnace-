using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using KonverSywul.Class;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Resources;
using System.Globalization;
using System.Xml.Serialization;

namespace KonverSywul
{
    public partial class Form1 : Form
    {

        private Class.DataInput _DataInput;
        private Class.DataOutput _DataOutput;
        private List<KonverSywul.Class.Param> _allParamsInput = new List<KonverSywul.Class.Param>(), _paramsToReportInput = new List<KonverSywul.Class.Param>();
        private List<KonverSywul.Class.Param> _allParamsOutput = new List<KonverSywul.Class.Param>(), _paramsToReportOutput = new List<KonverSywul.Class.Param>();

        public MathClass.Class1 c = new MathClass.Class1();
        public RepForm frmRpt;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1Main_Load(object sender, EventArgs e)
        {
            // Где будем искать .xml-файл с исходными данными 
            FileInfo fileDefaultUserAppDataPath = new FileInfo(Application.UserAppDataPath.ToString() + @"\\default.xml");

            if (fileDefaultUserAppDataPath.Exists)  // если файл найден, то десериализовать его
            {
                MathClass.Class1 ss = new MathClass.Class1();
                this.c = ss.LoadData(fileDefaultUserAppDataPath.ToString());
            }
            else  // если файла нет, то сформировать его и сериализовать в указанный каталог для последующего вызова
            {
                #region -- Загрузка первоначальных значений
                c.W = 0.35;
                c.W1 = 5.5;
                c.W2 = 0.5;
                c.T1 = 350;
                c.T2 = 290;
                c.A = 1.1;
                c.p = 0.9;
                c.T0 = 350;
                c.T2p = 290;
                c.T2p2 = 250;
                c.Cp1 = 1.74;
                c.Cp2 = 1.42;
                c.K = 3.76;
                c.Cm = 0.84;
                c.Cvl = 4.19;
                c.In = 2675;
                c.Cp = 2.09;
                c.Tm1 = 20;
                c.S = 0.23;
                c.D = 2.64;
                c.L = 2.78;
                c.H = 11.69;
                c.Tct2 = 60;
                c.CH4 = 99.26;
                c.C2H6 = 0.12;
                c.N2 = 0.61;
                c.CO2 = 0.01; //27
                #endregion -- Загрузка первоначальных значений

                // Сохранить параметры доступа к базе данных на диск для последующего вызова
                c.SaveData(c, fileDefaultUserAppDataPath.ToString());
            }

            textBox1.Text = c.W.ToString();
            textBox2.Text = c.W1.ToString();
            textBox3.Text = c.W2.ToString();
            textBox4.Text = c.T1.ToString();
            textBox5.Text = c.T2.ToString();
            textBox6.Text = c.A.ToString();
            textBox7.Text = c.p.ToString();
            textBox8.Text = c.T0.ToString();
            textBox9.Text = c.T2p.ToString();
            textBox10.Text = c.T2p2.ToString();
            textBox11.Text = c.Cp1.ToString();
            textBox12.Text = c.Cp2.ToString();
            textBox13.Text = c.K.ToString();
            textBox15.Text = c.Cm.ToString();
            textBox16.Text = c.Cvl.ToString();
            textBox17.Text = c.In.ToString();
            textBox22.Text = c.Cp.ToString();
            textBox23.Text = c.Tm1.ToString();
            textBox24.Text = c.S.ToString();
            textBox25.Text = c.D.ToString();
            textBox28.Text = c.L.ToString();
            textBox27.Text = c.H.ToString();
            textBox26.Text = c.Tct2.ToString();
            textBox18.Text = c.CH4.ToString();
            textBox19.Text = c.C2H6.ToString();
            textBox20.Text = c.N2.ToString();
            textBox21.Text = c.CO2.ToString();

            // Настроить элементы формы
            c.SaveData(c, fileDefaultUserAppDataPath.ToString());

            FormOptionDefault();
        }

        private void FormOptionDefault()
        {

            // Показать в заголовке главного окна номер текущей версии и пользвателя
            this.Text = this.Text + " [" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + "]";
            // Установить редактируемый объект в PropertyGrid
            _DataInput = new DataInput(c);
            _DataOutput = new DataOutput(c);
            //btn_OpenGR.Enabled = false;
            //btn_OpenReport.Enabled = false;

            string path = Application.UserAppDataPath.ToString() + @"\";

            #region -- Заполнить перечень показателей в отчет: исходные данные
            #region -- Исходные данные
            if (File.Exists(path + "cfgInputToRep.xml"))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<KonverSywul.Class.Param>));
                FileStream fs = null;
                try
                {
                    // Исходные данные
                    fs = new FileStream(path + "cfgInputToRepDP1.xml", FileMode.Open);
                    _allParamsInput = (List<KonverSywul.Class.Param>)xmls.Deserialize(fs);

                }
                catch
                {
                }
                finally
                {
                    if (fs != null) fs.Close();
                }
            }
            else
            {
                DataInput _dataIn = new DataInput(c);
                PropertyInfo[] pArrIn = _dataIn.GetType().GetProperties();
                if (pArrIn != null)
                    foreach (PropertyInfo p in pArrIn)
                    {
                        string descrIn = "";
                        object[] attrIn = p.GetCustomAttributes(false);
                        if (attrIn != null)
                            foreach (object a in attrIn)
                            {
                                if (a is DisplayNameAttribute) descrIn += (a as DisplayNameAttribute).DisplayName;
                                if (a is CategoryAttribute) descrIn = descrIn.Insert(0, (a as CategoryAttribute).Category + ", ");
                            }
                        KonverSywul.Class.Param parIn = new KonverSywul.Class.Param(0);
                        parIn.Description = descrIn;
                        parIn.IsReport = true;
                        parIn.PropertyName = p.Name;
                        _allParamsInput.Add(parIn);
                    }
            }
            #endregion -- Исходные данные
            #endregion

            #region -- Заполнить перечень показателей в отчет: результаты расчета
            if (File.Exists(path + "cfgOutputToRep.xml"))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<KonverSywul.Class.Param>));
                FileStream fsOut = null;
                try
                {
                    fsOut = new FileStream(path + "cfgOutputToRep.xml", FileMode.Open);
                    _allParamsOutput = (List<KonverSywul.Class.Param>)xmls.Deserialize(fsOut);
                }
                catch
                {
                }
                finally
                {
                    if (fsOut != null) fsOut.Close();
                }
            }
            else
            {
                DataOutput _dataOut = new DataOutput(c);
                PropertyInfo[] pArrOut = _dataOut.GetType().GetProperties();
                if (pArrOut != null)
                    foreach (PropertyInfo p in pArrOut)
                    {
                        string descrOut = "";
                        object[] attrOut = p.GetCustomAttributes(false);
                        if (attrOut != null)
                            foreach (object a in attrOut)
                            {
                                if (a is DisplayNameAttribute) descrOut += (a as DisplayNameAttribute).DisplayName;
                                if (a is CategoryAttribute) descrOut = descrOut.Insert(0, (a as CategoryAttribute).Category + ", ");
                            }
                        KonverSywul.Class.Param parOut = new KonverSywul.Class.Param(0);
                        parOut.Description = descrOut;
                        parOut.IsReport = true;
                        parOut.PropertyName = p.Name;
                        _allParamsOutput.Add(parOut);
                    }
            }
            #endregion

        }
        private void ProgramExit()
        {
            ReadInputDataFrom();
            c.SaveData(c, Application.UserAppDataPath.ToString() + @"\\default.xml");

            string path = Application.UserAppDataPath.ToString() + @"\"; // путь, куда запишем конфигурационные файлы .xml  
            #region -- сохранить параметры отчета в файле: исходные данные в отчет
            XmlSerializer xmls = new XmlSerializer(typeof(List<KonverSywul.Class.Param>));
            FileStream fsHB = null;

            try
            {
                //Исходные данные
                fsHB = new FileStream(path + "cfgInputToRepDP1.xml", FileMode.Create);
                xmls.Serialize(fsHB, _allParamsInput);
            }
            catch
            {
            }
            finally
            {
                if (fsHB != null) fsHB.Close();
            }
            #endregion

            #region -- сохранить параметры отчета в файле: результаты в отчет
            XmlSerializer xmlsOut = new XmlSerializer(typeof(List<KonverSywul.Class.Param>));
            FileStream fsOut = null;
            try
            {
                fsOut = new FileStream(path + "cfgOutputToRep.xml", FileMode.Create);
                xmlsOut.Serialize(fsOut, _allParamsOutput);
            }
            catch
            {
            }
            finally
            {
                if (fsOut != null) fsOut.Close();
            }
            #endregion

            Application.Exit();
        }


       





      

        private void button1_Click(object sender, EventArgs e)
        {
            ReadInputDataFrom();
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProgramExit();
        }
      
        private void ReadInputDataFrom()
        {
            c.W = double.Parse(textBox1.Text.ToString());
            c.W1 = double.Parse(textBox2.Text.ToString());
            c.W2 = double.Parse(textBox3.Text.ToString());
            c.T1 = double.Parse(textBox4.Text.ToString());
            c.T2 = double.Parse(textBox5.Text.ToString());
            c.A = double.Parse(textBox6.Text.ToString());
            c.p = double.Parse(textBox7.Text.ToString());
            c.T0 = double.Parse(textBox8.Text.ToString());
            c.T2p = double.Parse(textBox9.Text.ToString());
            c.T2p2 = double.Parse(textBox10.Text.ToString());
            c.Cp1 = double.Parse(textBox11.Text.ToString());
            c.Cp2 = double.Parse(textBox12.Text.ToString());
            c.K = double.Parse(textBox13.Text.ToString());
            c.Cm = double.Parse(textBox15.Text.ToString());
            c.Cvl = double.Parse(textBox16.Text.ToString());
            c.In = double.Parse(textBox17.Text.ToString());
            c.Cp = double.Parse(textBox22.Text.ToString());
            c.Tm1 = double.Parse(textBox23.Text.ToString());
            c.S = double.Parse(textBox24.Text.ToString());
            c.D = double.Parse(textBox25.Text.ToString());
            c.L = double.Parse(textBox28.Text.ToString());
            c.H = double.Parse(textBox27.Text.ToString());
            c.Tct2 = double.Parse(textBox26.Text.ToString());
            c.CH4 = double.Parse(textBox18.Text.ToString());
            c.C2H6 = double.Parse(textBox19.Text.ToString());
            c.N2 = double.Parse(textBox20.Text.ToString());
            c.CO2 = double.Parse(textBox20.Text.ToString());

        }

       

       

        private void РасчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox14.Text = c.T2pi().ToString("0.000");
            textBox29.Text = c.SumV0().ToString("0.000");
            textBox30.Text = c.L0().ToString("0.000");
            textBox31.Text = c.LA().ToString("0.000");
            textBox32.Text = c.VA().ToString("0.000");
            textBox33.Text = c.Q().ToString("0.000");
            textBox34.Text = c.I().ToString("0.000");
            textBox35.Text = c.VI().ToString("0.000");
            textBox36.Text = c.If().ToString("0.00");
            textBox37.Text = c.I0().ToString("0.00");
            textBox38.Text = c.i2p().ToString("0.00");
            textBox39.Text = c.X().ToString("0.00");
            textBox40.Text = c.Wc1().ToString("0.00");
            textBox61.Text = c.Wc2().ToString("0.00");
            textBox41.Text = c.Tm2().ToString("0.00");
            textBox42.Text = c.ivl().ToString("0.00");
            textBox43.Text = c.Q1().ToString("0.00");
            textBox44.Text = c.qx().ToString("0.00");
            textBox62.Text = c.Q2().ToString("0.00");
            textBox63.Text = c.Q5().ToString("0.00");
            textBox45.Text = c.QW().ToString("0.00");
            textBox46.Text = c.Q5W().ToString("0.00");
            textBox47.Text = c.Q5t().ToString("0.00");
            textBox48.Text = c.tct1().ToString("0.00");
            textBox49.Text = c.yyy().ToString("0.00");
            textBox50.Text = c.SS().ToString("0.00");
            textBox51.Text = c.F2().ToString("0.00");
            textBox52.Text = c.F1().ToString("0.00");
            textBox53.Text = c.Fct().ToString("0.00");
            textBox54.Text = c.Q5pn().ToString("0.00");
            textBox56.Text = c.QQQ().ToString("0.00");
            textBox57.Text = c.Qucp().ToString("0.00");
            textBox58.Text = c.Vtop().ToString("0.00");
            textBox59.Text = c.OM().ToString("0.00");
            textBox60.Text = c.Htop().ToString("0.00");
        }

        private bool CheckPoint(TextBox TxtB)
        {
            if (TxtB == null || TxtB.Text == "")
                return false;
            else
                return true;
        }

        /// <summary>
        /// Проверить введенные в текстовое поле данные. 
        /// </summary>  
        /// <param name="strTxtB">Введенное в поле значение</param>
        private bool CheckPoint(string strTxtB)
        {
            float fl;
            if (!float.TryParse(strTxtB, out fl))
                return false;
            else
                return true;
        }


  

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox28_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox27_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox26_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ifrm = new frmAbout ();
            ifrm.Show();
        }

  


        private void руководствоПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            {
                Process SysInfo = new Process();
                SysInfo.StartInfo.ErrorDialog = true;
                SysInfo.StartInfo.FileName = Application.StartupPath + "\\kladka_hlp.chm";
                SysInfo.Start();
            }
           
        }

        private void графикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiagramma D = new frmDiagramma(c);
            D.ShowDialog();
        }

        private void показатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateReportViewer();

        }

        private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportOptions _ro = new frmReportOptions(_allParamsInput, _allParamsOutput);
            _ro.ShowDialog();
        }

        public void CreateReportViewer()
        {
            frmRpt = new RepForm();

            // Исходные данные в отчет только те, которые отметил пользователь (IsReport=true)
            DataInput _DataInput = new DataInput(c);
            List<cReportList> RepListInput = new List<cReportList>();
            foreach (KonverSywul.Class.Param par in _allParamsInput)
            {
                if (par.IsReport)
                {
                    if (_DataInput.GetType().GetProperty(par.PropertyName).GetValue(_DataInput, null) != null)
                    {
                        double d = Math.Round(Convert.ToDouble(
                            _DataInput.GetType().GetProperty(par.PropertyName).GetValue(
                            _DataInput, null)), 3);
                        RepListInput.Add(new KonverSywul.Class.cReportList(par.Description, d.ToString()));
                    }
                }
            }
            frmRpt.cReportInputBindingSource.DataSource = RepListInput;
            // Результаты расчета в отчет только те, которые отметил пользователь (IsReport=true)
            DataOutput _DataOutput = new DataOutput(c);
            List<cReportList> RepListOutput = new List<cReportList>();
            foreach (KonverSywul.Class.Param par in _allParamsOutput)
            {
                if (par.IsReport)
                {
                    double d = Math.Round(Convert.ToDouble(
                        _DataOutput.GetType().GetProperty(par.PropertyName).GetValue(_DataOutput, null)), 3);
                    RepListOutput.Add(new KonverSywul.Class.cReportList(par.Description, d.ToString()));
                }
            }

            // Указать отчету источники данных                
            frmRpt.cReportInputBindingSource.DataSource = RepListInput;
            frmRpt.cParamOutputBindingSource.DataSource = RepListOutput;
            // Показать окно отчета на весь экран
            frmRpt.WindowState = FormWindowState.Maximized;
            frmRpt.ShowDialog(this);

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
   char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }
    }
}
