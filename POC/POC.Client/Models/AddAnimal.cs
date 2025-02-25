namespace POC.Client.Models
{
    public class AddAnimalModel
    {
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public bool IsVaccinated { get; set; }
        public DateTime? VaccinationDate { get; set; }
    }
}
