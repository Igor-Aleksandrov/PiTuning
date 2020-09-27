using System.ComponentModel;

namespace PItuning.Models.Controllers
{   
    /// <summary>
    /// Calculating settings for PID Controller Gain (Kc), Integral Time (Ti), and Derivative Time (Td) using different Rules.
    /// TypeRule is assigned sfter calculating Controller's parameters by one of the Rules.
    /// Defult value - None, Controller's tunning parameters were not calculated.
    /// </summary>
    public enum TypeRule
    {
        None = -1,   // Controller's tunning parameters were not calculated
        CohenCoonRule,
        ZieglerNicholsRule,
        LamdaRule,
        ISE,
        IAE,
        ITAE
    }

    /// <summary>
    /// The Proportional, Integral and Derivative modes are arranged into different controller algorithms or controller structures:
    /// 0 - Noninteractive Algorithm;
    /// 1 - Interactive Algorithm;
    /// 2 - Parallel Algorithm;
    /// 3 - CentumVP basic type PID control.
    /// </summary>
    public enum TypeAlgorithm
    {
        Noninteractive = 0,
        Interactive,
        Parallel,
        CentumPID
    }

    /// <summary>
    /// Contains a controller's tunning parameters.
    /// </summary>
    public abstract class Controller : INotifyPropertyChanged
    {
        private double p, i, d;

        public TypeAlgorithm TypeAlg { get; set; }
        public TypeRule TypeM { get; set; }

        /// <summary>
        /// Proportional parameter (Kc, Kc, Kp or PB).
        /// </summary>
        public double P
        {
            get { return p; }
            set
            {
                if (p != value)
                {
                    p = value; //TODO contract programming
                    OnPropertyChanged("P");
                }
            }
        }
        /// <summary>
        /// Integral parameter (Ti, Ti, Ki or Ti).
        /// </summary>
        public double I
        {
            get { return i; }
            set
            {
                if (i != value)
                {
                    i = value;
                    OnPropertyChanged("I");
                }
            }
        }
        /// <summary>
        /// Derivative parameter (Td, Td, Kd or Td).
        /// </summary>
        public double D
        {
            get { return d; }
            set
            {
                if (d != value)
                {
                    d = value;
                    OnPropertyChanged("D");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
