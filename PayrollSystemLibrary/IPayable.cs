using System.Diagnostics.CodeAnalysis;

namespace PayrollSystem
{
    
    public interface IPayable
    {
        
        public float Pay()
        {
            float sum = 5;
            return sum;
        }
    }
}