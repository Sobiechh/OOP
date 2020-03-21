namespace Kalkulator
{
    public partial class MainWindow
    {
        public class Numerki
        {
            public double firstNumber { get; set; }
            public double secondNumber { get; set; }

            public string infoValue
            {
                get { 
                    return infoValue; 
                }

                set
                {
                    if (value != infoValue)
                        infoValue = value;
                }
            }
        }

        
    }
}
