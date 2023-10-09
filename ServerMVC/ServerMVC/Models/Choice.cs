namespace ServerMVC.Models
{
    public class Choice
    {
        public int RadioOne { get; set; }
        public int RadioThree { get; set; }
        public Choice(int radioOne, int radioThree)
        {
            this.RadioOne = radioOne;
            this.RadioThree = radioThree;
        }
    }
}
