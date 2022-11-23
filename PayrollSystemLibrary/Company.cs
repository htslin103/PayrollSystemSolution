namespace PayrollSystem
{
    public class Company
    {
        public Company() 
        { 

            Resources = new List<IPayable>();
        }
        //Will tweak this later so it's read only except hire and term
        public ICollection<IPayable> Resources { get; set; }

        public void Hire(IPayable payable)
        {
            Resources.Add(payable);
        } 

        public void Terminate(IPayable payable)
        {
            Resources.Remove(payable);
        }

        public float Pay()
        {
            return Resources.Sum(p => p.Pay());
        }
    }
}