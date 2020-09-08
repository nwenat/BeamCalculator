using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WpfApp1._0
{
    class Loads : INotifyPropertyChanged
    {
        // load kN/m
        private Double dGLoad = 20.0;
        private Double qLoad = 12.0;

        // sila kN
        private Double silaP = 0.0;

        private StaticSystemTypes staticSystem = StaticSystemTypes.jednoprzeslowa;
        private String staticSystemDescription = EnumDescribe.GetDescribe(StaticSystemTypes.jednoprzeslowa);

        public event PropertyChangedEventHandler PropertyChanged;

        public Double DGLoad
        {
            get
            {
                return dGLoad;
            }
            set
            {
                dGLoad = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DGLoad"));
            }
        }

        public Double QLoad
        {
            get
            {
                return qLoad;
            }
            set
            {
                qLoad = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QLoad"));
            }
        }

        public Double SilaP
        {
            get
            {
                return silaP;
            }
            set
            {
                silaP = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SilaP"));
            }
        }

        public StaticSystemTypes StaticSystem
        {
            get
            {
                return staticSystem;
            }
        }

        public Array TypesOfStaticSystems
        {
            get
            {
                List<StaticSystemTypes> list = Enum.GetValues(typeof(StaticSystemTypes)).OfType<StaticSystemTypes>().ToList();
                List<String> result = new List<String>();
                foreach (StaticSystemTypes sC in list)
                {
                    var descript = EnumDescribe.GetDescribe(sC);
                    result.Add(descript);
                }
                return result.ToArray();
            }
        }

        public String StaticSystemDescription
        {
            set
            {
                staticSystemDescription = value;
                staticSystem = EnumDescribe.GetValueFromDescription<StaticSystemTypes>(staticSystemDescription);
                PropertyChanged(this, new PropertyChangedEventArgs("StaticSystemDescription"));
            }
            get
            {
                return staticSystemDescription;
            }
        }

        public enum StaticSystemTypes
        {
            [Description("jednoprzęsłowa wolnopodparta")]
            jednoprzeslowa,
            [Description("wolnopodparta z przewieszeniem")]
            przewieszenie,
            [Description("jednoprzęsłowa zamocowana z jednej strony")]
            jednoZamocowanie,
            [Description("jednoprzęsłowa zamocowana z dwóch stron")]
            dwaZamocowania
            //[Description("Belka dwuprzęsłowa")]
            //dwuprzeslowa,
            //[Description("Belka trzyprzęsłowa")]
            //trzyprzeslowa
        }
    }
}
