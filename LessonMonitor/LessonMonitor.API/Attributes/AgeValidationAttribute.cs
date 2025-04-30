namespace LessonMonitor.API.Attributes
{
    public class AgeValidationAttribute : Attribute
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public AgeValidationAttribute(int minValue, int maxValue) {  MinValue = minValue; MaxValue = maxValue; }
    }
}
