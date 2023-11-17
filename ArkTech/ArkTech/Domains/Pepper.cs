namespace ArkTech.Domains
{
    public class Pepper
    {
        private string pepperStr;
        public Pepper()
        {
            PepperStr = "Bananas";
        }
        public string PepperStr
        {
            get { return pepperStr; }
            private set { pepperStr = value; }
        }
    }
}
