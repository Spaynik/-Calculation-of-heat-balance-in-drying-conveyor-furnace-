using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace MathClass
{

    [Serializable]
    public class Class1
    {
        /// <summary>
        /// Загрузить исходные данные в экземпляр объекта расчета 
        /// </summary>  
        /// <param name="NameFile">Имя файла для извлечения данных</param>
        /// 
        #region Сериализ
        public Class1 LoadData(string FileName)
        {
            // Восстановить данные путем десериализации из XML-файла
            SoapFormatter myXMLFormat = new SoapFormatter();
            FileStream myStreamB = File.OpenRead(FileName);
            Class1 _c = (Class1)myXMLFormat.Deserialize(myStreamB);
            myStreamB.Close();
            return _c;
        }

        /// <summary>
        /// Сохранение исходных данных объекта на диск
        /// </summary>  
        /// <param name="hc">Объект  для сохранения на диск</param>
        /// <param name="NameFile">Имя файла для сохранения</param>
        public void SaveData(Class1 c, string NameFile)
        {
            FileStream myStream = File.Create(NameFile);
            SoapFormatter myXMLFormat = new SoapFormatter();
            myXMLFormat.Serialize(myStream, c);
            myStream.Close();
        }
        #endregion Сериализ

        private string _sFileName;    // закрытая переменная класса для хранения имени файла исходных данных
        public string FileName
        {
            get { return _sFileName; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentException("Не определен объект FileName");
                else
                    _sFileName = value;
            }
        }

        /// <summary>
        /// Производительность печи по сухому материалу, W
        /// </summary> 
        /// 
        #region исходные данные перем
        private double _W;    // закрытая переменная класса 1
        public double W
        {
            get { return _W; }
            set { _W = value; }
        }

        private double _W1;    // закрытая переменная класса 2
        public double W1
        {
            get { return _W1; }
            set { _W1 = value; }
        }

        private double _W2;    // закрытая переменная класса 3
        public double W2
        {
            get { return _W2; }
            set { _W2 = value; }
        }

        private double _T1;    // закрытая переменная класса 4
        public double T1
        {
            get { return _T1; }
            set { _T1 = value; }
        }

        private double _T2;    // закрытая переменная класса 5
        public double T2
        {
            get { return _T2; }
            set { _T2 = value; }
        }

        private double _A;    // закрытая переменная класса 6
        public double A
        {
            get { return _A; }
            set { _A = value; }
        }

        private double _p;    // закрытая переменная класса 7
        public double p
        {
            get { return _p; }
            set { _p = value; }
        }

        private double _T0;    // закрытая переменная класса 8
        public double T0
        {
            get { return _T0; }
            set { _T0 = value; }
        }

        private double _T2p;    // закрытая переменная класса 9
        public double T2p
        {
            get { return _T2p; }
            set { _T2p = value; }
        }

        private double _T2p2;    // закрытая переменная класса 10
        public double T2p2
        {
            get { return _T2p2; }
            set { _T2p2 = value; }
        }

        private double _Cp1;    // закрытая переменная класса 11
        public double Cp1
        {
            get { return _Cp1; }
            set { _Cp1 = value; }
        }

        private double _Cp2;    // закрытая переменная класса 12
        public double  Cp2
        {
            get { return _Cp2; }
            set { _Cp2 = value; }
        }

        private double _K;    // закрытая переменная класса 13
        public double K
        {
            get { return _K; }
            set { _K = value; }
        }

        private double _Cm;    // закрытая переменная класса 14
        public double Cm
        {
            get { return _Cm; }
            set { _Cm = value; }
        }

        private double _Cvl;    // закрытая переменная класса 15
        public double Cvl
        {
            get { return _Cvl; }
            set { _Cvl = value; }
        }

        private double _In;    // закрытая переменная класса 16
        public double In
        {
            get { return _In; }
            set { _In = value; }
        }

        private double _Cp;    // закрытая переменная класса 17
        public double Cp
        {
            get { return _Cp; }
            set { _Cp = value; }
        }

        private double _Tm1;    // закрытая переменная класса 18
        public double Tm1
        {
            get { return _Tm1; }
            set { _Tm1 = value; }
        }


        private double _S;    // закрытая переменная класса 19
        public double S
        {
            get { return _S; }
            set { _S = value; }
        }

        private double _D;    // закрытая переменная класса 20
        public double D
        {
            get { return _D; }
            set { _D = value; }
        }

        private double _L;    // закрытая переменная класса 21
        public double L
        {
            get { return _L; }
            set { _L = value; }
        }

        private double _H;    // закрытая переменная класса 22
        public double H
        {
            get { return _H; }
            set { _H = value; }
        }

        private double _Tct2;    // закрытая переменная класса 23
        public double Tct2
        {
            get { return _Tct2; }
            set { _Tct2 = value; }
        }

        private double _CH4;    // закрытая переменная класса 24
        public double CH4
        {
            get { return _CH4; }
            set { _CH4 = value; }
        
        }

        private double _C2H6;    // закрытая переменная класса 25
        public double C2H6
        {
            get { return _C2H6; }
            set { _C2H6 = value; }
        }

        private double _N2;    // закрытая переменная класса 26
        public double N2
        {
            get { return _N2; }
            set { _N2 = value; }
        }

        private double _CO2;    // закрытая переменная класса 27
        public double CO2
        {
            get { return _CO2; }
            set { _CO2 = value; }
        }
        #endregion исходные данные перем

        #region Горение топлива
        private double _T2pi;    // закрытая переменная класса 
        public double T2pi()
        {
            return _T2pi = _T2p * 1.433;

        }
        private double _SumV0;    // закрытая переменная класса 
        public double SumV0()
        {
            return _SumV0 = ((2*CH4/100)+(2*C2H6/100)+(1.5*C2H6/100));
        }


        private double _L0;    // закрытая переменная класса 
        public double L0()
        {
            return _L0 = (1 + K) * _SumV0;
        }

        private double _LA;    // закрытая переменная класса 
        public double LA()
        {
            return _LA = A * _L0;
        }

        private double _VA;    // закрытая переменная класса 
        public double VA()
        {
            return _VA = (2 * CH4/100 + 3.5 * C2H6/100) + (CO2/100 + CH4/100 + 2 * C2H6/100) + N2/100 + A * K * _SumV0 + ( A - 1) * _SumV0;
        }


        private double _Q;    // закрытая переменная класса 
        public double Q()
        {
            return _Q = (358 * CH4/100 + 636 * C2H6/100) * 100;

        }

        private double _I;    // закрытая переменная класса 
        public double I()
        {
            return _I = ( _Q + _LA * 20 * 1.29 + 1 * 20 * 1.57) / _VA;

        }

        private double _VI;    // закрытая переменная класса 
        public double VI()
        {
            return _VI = ((_LA - _L0) * 100) / _VA;

        }

        private double _If;    // закрытая переменная класса 
        public double If()
        {
            return _If = _I * p;

        }
        #endregion горения топлива

        #region газодинамический
        private double _I0;    // закрытая переменная класса 
        public double I0()
        {
            return _I0 = _T2p * _Cp1;

        }

        private double _i2p;    // закрытая переменная класса 
        public double i2p()
        {
            return _i2p = _Cp2 * _T2p2;

        }

        private double _X;    // закрытая переменная класса 
        public double X()
        {
            return _X = (_If - _I0) / (_I0 - _i2p);

        }
        #endregion

        #region Тепловой баланс 

        private double _Wc1;    // закрытая переменная класса 
        public double Wc1()
        {
            return _Wc1 = _W1 / (1 - 0.01 * _W1);

        }

        private double _Wc2;    // закрытая переменная класса 
        public double Wc2()
        {
            return _Wc2 = _W2 / (1 - 0.01 * _W2);

        }

        private double _Tm2;    // закрытая переменная класса 
        public double Tm2()
        {
            return _Tm2 = 0.5 * (_T1 + _T2) - 100;
        }

        private double _ivl;    // закрытая переменная класса 
        public double ivl()
        {
            return _ivl = _Cvl * _Tm1;

        }


        public double _Q1;    // закрытая переменная класса 
        public double Q1()
        {
            return _Q1 =  ((_Cm + 0.01 * _Wc2 * _Cvl) * (_Tm2 - _Tm1) + 0.01 * (_Wc1 - _Wc2) * (_In - _ivl + _Cp * (_T2 - 100))) * W;

        }

        private double _qx;    // закрытая переменная класса 
        public double qx()
        {
            return _qx = _Q ;

        }
       // private double _Q2;    // закрытая переменная класса 
        public double Q2()
        {
            return (_T2pi + _X * (_T2pi - _i2p)) * _VA;

        }

       //  private double _QW;    // закрытая переменная класса 
        public double QW()
        {
            return  Q2() * 0.01;

        }
        //private double _Q5;    // закрытая переменная класса 
        public double Q5()
        {
            return  (1 - _p)* Q();

        }

       // private double _Q5W;    // закрытая переменная класса 
        public double Q5W()
        {
            return  Q5() * 0.01;

        } 

        private double _Q5t;    // закрытая переменная класса 
        public double Q5t()
        {
            return _Q5t = 500;

        }

        private double _tct1;    // закрытая переменная класса 
        public double tct1()
        {
            return _tct1 = 0.5*(_T0 + _T2p);

        }

        private double _yyy;    // закрытая переменная класса 
        public double yyy()
        {
            return _yyy = 0.088 + 0.09 * 0.0001 * ((_tct1 + _Tct2) / 2);

        }

        private double _SS;    // закрытая переменная класса 
        public double SS()
        {
            return _SS = _yyy * (_tct1 - _Tct2) / (0.8 * _Q5t);

        }

        private double _F2;    // закрытая переменная класса 
        public double F2()
        {
            return _F2 = (_D * _L + _H * _D + _H * _L) * 2;

        }

        private double _F1;    // закрытая переменная класса 
        public double F1()
        {
            return _F1 = (_D * _L + _H * _L + _H * 2 * _L);

        }

        private double _Fct;    // закрытая переменная класса 
        public double Fct()
        {
            return _Fct = 0.5 * (_F2 + _F1);

        }

       // private double _Q5pn;    // закрытая переменная класса 
        public double Q5pn()
        {
            return (_yyy / _SS) * (_tct1 - _Tct2) * _Fct * 0.001;

        }

        private double _QQQ;    // закрытая переменная класса 
        public double QQQ()
        {
            return _QQQ = _qx * 0.01;

        }

        private double _Qucp;    // закрытая переменная класса 
        public double Qucp()
        {
            return _Qucp = ((Q1() + QW() + Q5W() + Q5pn() )/ (0.01 * (_Wc1 - _Wc2) * _W));

        }

        private double _Vtop;    // закрытая переменная класса 
        public double Vtop()
        {
            return _Vtop = (0.01 * _qx) / 150;

        }


        private double _OM;    // закрытая переменная класса 
        public double OM()
        {
            return _OM = (_D - 2 * _S) * (0.5 * _L - 2 * _S);

        }

        private double _Htop;    // закрытая переменная класса 
        public double Htop()
        {
            return _Htop = _Vtop / _OM;

        }

        #endregion

    }
}
