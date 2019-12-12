using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MathClass;

namespace KonverSywul.Class
{
    [Serializable]
    class DataInput
    {
        private Class1 _c = new Class1();
        public DataInput(Class1 c)
        {
            _c = c;
        }
        #region ---Исходные данные


        [Description("Производительность печи по сухому материалу, W%")]
        [DisplayName("Производительность печи по сухому материалу, W%")]
        public double W
        {
            get { return _c.W; }
            set { _c.W = value; }
        }

        [Description("Начальная влажность стержней, W1%")]
        [DisplayName("Начальная влажность стержней, W1%")]
        public double W1
        {
            get { return _c.W1; }
            set { _c.W1 = value; }
        }

        [Description("Конечная влажность стержней, W2")]
        [DisplayName("Конечная влажность стержней, W2")]
        public double W2
        {
            get { return _c.W2; }
            set { _c.W2 = value; }
        }

        [Description("Максимальная температура сушки, t1")]
        [DisplayName("Максимальная температура сушки, t1")]
        public double T1
        {
            get { return _c.T1; }
            set { _c.T1 = value; }
        }

        [Description("Температура отходящих газов, t2")]
        [DisplayName("Температура отходящих газов, t2")]
        public double T2
        {
            get { return _c.T2; }
            set { _c.T2 = value; }
        }

        [Description("Коэффицент расхода воздуха, α")]
        [DisplayName("Коэффицент расхода воздуха, α")]
        public double A
        {
            get { return _c.A; }
            set { _c.A = value; }
        }

        [Description("Пирометрический коэффициент, ŋпир")]
        [DisplayName("Пирометрический коэффициент, ŋпир")]
        public double p
        {
            get { return _c.p; }
            set { _c.p = value; }
        }

        [Description("Начальная температура, t0")]
        [DisplayName("Начальная температура, t0")]
        public double T0
        {
            get { return _c.T0; }
            set { _c.T0 = value; }
        }

        [Description("Рециркулят покидает рабочее пространство с температурой, t2p")]
        [DisplayName("Рециркулят покидает рабочее пространство с температурой, t2p")]
        public double T2p
        {
            get { return _c.T2p; }
            set { _c.T2p = value; }
        }

        [Description("В результате движения его температура снижается до t2p")]
        [DisplayName("В результате движения его температура снижается до t2p")]
        public double T2p2
        {
            get { return _c.T2p2; }
            set { _c.T2p2 = value; }
        }

        [Description("Средняя объемная теплоемкость CH4 при температуре 290 °С, Ср1")]
        [DisplayName("Средняя объемная теплоемкость CH4 при температуре 290 °С, Ср1")]
        public double Cp1
        {
            get { return _c.Cp1; }
            set { _c.Cp1 = value; }
        }

        [Description("Средняя объемная теплоемкость рециркулята при температуре 250 °С, Ср2")]
        [DisplayName("Средняя объемная теплоемкость рециркулята при температуре 250 °С, Ср2")]
        public double Cp2
        {
            get { return _c.Cp2; }
            set { _c.Cp2 = value; }
        }

        [Description("Рассчетный коэффициент к")]
        [DisplayName("Рассчетный коэффициент к")]
        public double K
        {
            get { return _c.K; }
            set { _c.K = value; }
        }

        [Description("Удельная теплоемкость сухого материала в  интервале указанных температур, сm")]
        [DisplayName("Удельная теплоемкость сухого материала в  интервале указанных температур, сm")]
        public double Cm
        {
            get { return _c.Cm; }
            set { _c.Cm = value; }
        }

        [Description("Удельная теплоемкость влаги, свл")]
        [DisplayName("Удельная теплоемкость влаги, свл")]
        public double Cvl
        {
            get { return _c.Cvl; }
            set { _c.Cvl = value; }
        }

        [Description("Удельная энтальпия водяного пара при 100 °C, iп100")]
        [DisplayName("Удельная энтальпия водяного пара при 100 °C, iп100")]
        public double In
        {
            get { return _c.In; }
            set { _c.In = value; }
        }

        [Description("На перегрев 1 кг пара до t2 затрачивается теплоты пропорционально удельной теплоемкости пара, сп")]
        [DisplayName("На перегрев 1 кг пара до t2 затрачивается теплоты пропорционально удельной теплоемкости пара, сп")]
        public double Cp
        {
            get { return _c.Cp; }
            set { _c.Cp = value; }
        }

        [Description("Температура топлива и воздуха, попадаемого в горелку, tm1")]
        [DisplayName("Температура топлива и воздуха, попадаемого в горелку, tm1")]
        public double Tm1
        {
            get { return _c.Tm1; }
            set { _c.Tm1 = value; }
        }

        [Description("Толщина кладки топки, S")]
        [DisplayName("Толщина кладки топки, S")]
        public double S
        {
            get { return _c.S; }
            set { _c.S = value; }
        }

        [Description("Ширина D ")]
        [DisplayName("Ширина D ")]
        public double D
        {
            get { return _c.D; }
            set { _c.D = value; }
        }

        [Description("Длина, L")]
        [DisplayName("Длина, L")]
        public double L
        {
            get { return _c.L; }
            set { _c.L = value; }
        }

        [Description("Высота H")]
        [DisplayName("Высота Н")]
        public double H
        {
            get { return _c.H; }
            set { _c.H = value; }
        }

        [Description("Температура наружной поверхности стенок, tст2")]
        [DisplayName("Температура наружной поверхности стенок, tст2")]
        public double Tct2
        {
            get { return _c.Tct2; }
            set { _c.Tct2 = value; }
        }

        [Description("CH4")]
        [DisplayName("CH4")]
        public double CH4
        {
            get { return _c.CH4; }
            set { _c.CH4 = value; }

        }

        [Description("C2H6")]
        [DisplayName("C2H6")]
        public double C2H6
        {
            get { return _c.C2H6; }
            set { _c.C2H6 = value; }
        }

        [Description("N2")]
        [DisplayName("N2")]
        public double N2
        {
            get { return _c.N2; }
            set { _c.N2 = value; }
        }

        [Description("CO2")]
        [DisplayName("CO2")]
        public double CO2
        {
            get { return _c.CO2; }
            set { _c.CO2 = value; }
        }

        #endregion
    }

    
}

