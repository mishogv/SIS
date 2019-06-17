namespace SULS.App.ViewModels.Problems
{
    using SIS.MvcFramework.Attributes.Validation;

    public class CreateProblemBindingModel
    {
        private const string NameError = "Name should be between 5 and 20 characters!";

        private const string PointsError = "Points should be between 50 and 300!";

        [RequiredSis]
        [StringLengthSis(5, 20, NameError)]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(50, 300, PointsError)]
        public int Points { get; set; }
    }
}