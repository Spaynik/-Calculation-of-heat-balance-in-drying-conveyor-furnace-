using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MathClass;

namespace KonverSywul.Class
{
    [Serializable]
    public class DataOutput
    {

        private Class1 c_ = new Class1();
        public DataOutput(Class1 c)
        {
            _c = c;
        }
        #region ---Результат расчета теплового баланса сушильного барабана
        /// <summary>
        /// Расход теплоты на прогревание просушиваемых материалов и испарение влаги
        /// </summary>
        [Description("Определим начальную влажность материала, отнесенную к сухой массе %")]
        [DisplayName("Определим начальную влажность материала, отнесенную к сухой массе %")]
        public double Get_Q1
        {
            get { return _c.Wc1(); }
        }
        /// <summary>
        /// Потери теплоты с отходящими газами
        /// </summary>
        [Description("Определим конечную влажность материала, отнесенную к сухой массе %")]
        [DisplayName("Определим конечную влажность материала, отнесенную к сухой массе %")]
        public double Get_Q2
        {
            get { return _c.Wc2(); }
        }
        /// <summary>
        /// Потери теплоты с химическим недожогом
        /// </summary>
        [Description("Рассчитаем температуру массы стержней в конце сушки °C")]
        [DisplayName("Рассчитаем температуру массы стержней в конце сушки °C")]
        public double Get_Q3
        {
            get { return _c.Tm2(); ; }
        }
        /// <summary>
        /// Потери телпоты вследствие теплопроводности стенок рабочего пространства
        /// </summary>
        [Description("Начальная удельная энтальпия воды Кдж/кг")]
        [DisplayName("Начальная удельная энтальпия воды Кдж/кг")]
        public double Get_Q5t
        {
            get { return _c.ivl(); }
        }
        /// <summary>
        /// Потери теплоты топкой
        /// </summary>
        [Description("Определим искомую статью баланса кВт")]
        [DisplayName("Определим искомую статью баланса кВт")]
        public double Get_Q5top
        {
            get { return _c.Q1(); }
        }
        /// <summary>
        /// Тепловая мощность печи
        /// </summary>
        [Description("Химическая энергия топлива кВт")]
        [DisplayName("Химическая энергия топлива кВт")]
        public double Get_Qx
        {
            get { return _c.qx(); }
        }
        /// <summary>
        /// Расход теплоты на 1 кг испаренной влаги
        /// </summary>
        [Description("Определим потери теплоты с отходящими газами В")]
        [DisplayName("Определим потери теплоты с отходящими газами В")]
        public double Get_qisp
        {
            get { return _c.Q2(); }
        }
        /// <summary>
        /// КПД печи
        /// </summary>
        [Description("Определим потери теплоты с отходящими газами кВт")]
        [DisplayName("Определим потери теплоты с отходящими газами кВт")]
        public double Get_Q1pr
        {
            get { return _c.QW(); }
        }
        /// <summary>
        /// Расход мазута
        /// </summary>
        [Description("Определим потери теплоты топкой, использую пирометрический коэфффицент В")]
        [DisplayName("Определим потери теплоты топкой, использую пирометрический коэфффицент В")]
        public double Get_B
        {
            get { return _c.Q5(); }
        }
        /// <summary>
        /// Расход мазута
        /// </summary>
        [Description("Определим потери теплоты топкой, использую пирометрический коэфффицент кВт")]
        [DisplayName("Определим потери теплоты топкой, использую пирометрический коэфффицент кВт")]
        public double Get_B1
        {
            get { return _c.Q5W(); }
        }


        [Description("Потери теплоты теплопроводностью через стены рабочего пространств Вт/м2")]
        [DisplayName("Потери теплоты теплопроводностью через стены рабочего пространств Вт/м2")]
        public double Get_Q
        {
            get { return _c.Q5t(); }
        }

        [Description("Найдем среднюю температуру внутренней поверхности стенок рабочего пространства °С")]
        [DisplayName("Найдем среднюю температуру внутренней поверхности стенок рабочего пространства °С")]
        public double Get_W
        {
            get { return _c.tct1(); }
        }

        [Description("Коэффициент теплопроводности стен Вт/(м*к)")]
        [DisplayName("Коэффициент теплопроводности стен Вт/(м*к)")]
        public double Get_e
        {
            get { return _c.yyy(); }
        }

        [Description("Толщина стенок рабочего пространства м")]
        [DisplayName("Толщина стенок рабочего пространства м")]
        public double Get_r
        {
            get { return _c.SS(); }
        }

        [Description("Наружная поверхность рабочей камеры м2")]
        [DisplayName("Наружная поверхность рабочей камеры м2")]
        public double Get_t
        {
            get { return _c.F2(); }
        }

        [Description("Внутрення поверхность рабочей камеры м2")]
        [DisplayName("Внутрення поверхность рабочей камеры м2")]
        public double Get_y
        {
            get { return _c.F1(); }
        }

        [Description("Средняя теплопроводящая поверхность стенок м2")]
        [DisplayName("Средняя теплопроводящая поверхность стенок м2")]
        public double Get_u
        {
            get { return _c.Fct(); }
        }

        [Description("Потери теплоты теплопроводностью через стенки печи кВт")]
        [DisplayName("Потери теплоты теплопроводностью через стенки печи кВт")]
        public double Get_i
        {
            get { return _c.Q5pn(); }
        }
        private Class1 _c = new Class1();

        [Description("Тепловая мощность печи кВт")]
        [DisplayName("Тепловая мощность печи кВт")]
        public double Get_o
        {
            get { return _c.QQQ(); }
        }

        [Description("Расход теплоты на 1 кг испаренной влаги кДж/кг")]
        [DisplayName("Расход теплоты на 1 кг испаренной влаги кДж/кг")]
        public double Get_Bp
        {
            get { return _c.Qucp(); }
        }

        [Description("Рассчитаем объем топки для сжигания газа кДж/кг")]
        [DisplayName("Рассчитаем объем топки для сжигания газа кДж/кг")]
        public double Get_a
        {
            get { return _c.Vtop(); }
        }

        [Description("Найдем внутреннее сечение топки м3")]
        [DisplayName("Найдем внутреннее сечение топки м3")]
        public double Get_s
        {
            get { return _c.OM(); }
        }

        [Description("Высота топки в свету м")]
        [DisplayName("Высота топки в свету м")]
        public double Get_d
        {
            get { return _c.Htop(); }
        }

        #endregion
     
    }
}
