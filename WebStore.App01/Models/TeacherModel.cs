using Newtonsoft.Json;

namespace WebStore.App01.Models
{

	public class TeacherModel
	{
		/// <summary>
		/// сведения о фамилии, имени, отчестве
		/// педагогического работника образовательной организации
		/// </summary>
		[JsonProperty("fio")]
		public string FIO { get; set; }

		/// <summary>
		/// сведения об учёной степени педагогического
		/// работника образовательной организации
		/// </summary>
		[JsonProperty("degree")]
		public string Degree { get; set; }

		/// <summary>
		/// сведения об учёном звании педагогического
		/// работника образовательной организации
		/// </summary>
		[JsonProperty("academStat")]
		public string AcademStat { get; set; }

		/// <summary>
		/// уровень образования
		/// </summary>
		[JsonProperty("teachingLevel")]
		public string TeachingLevel { get; set; }

		/// <summary>
		/// квалификация
		/// </summary>
		[JsonProperty("teachingQual")]
		public string TeachingQual { get; set; }

		/// <summary>
		/// сведения о занимаемой должности (должностях)
		/// педагогического работника образовательной организации
		/// </summary>
		[JsonProperty("post")]
		public string[] Post { get; set; }

		/// <summary>
		/// сведения о преподаваемых дисциплинах
		/// </summary>
		[JsonProperty("teachingDiscipline")]
		public string[] TeachingDisciplines { get; set; }

		/// <summary>
		/// сведения о наименовании направления
		/// подготовки и (или) специальности педагогического работника
		/// </summary>
		[JsonProperty("employeeQualification")]
		public string EmployeeQualification { get; set; }

		/// <summary>
		/// сведения о повышении квалификации и (или)
		/// профессиональной переподготовке (при наличии)
		/// </summary>
		[JsonProperty("profDevelopment")]
		public string[] ProfDevelopment { get; set; }

		/// <summary>
		/// сведения об общем стаже работы педагогического работника
		/// </summary>
		[JsonProperty("genExperience")]
		public string GenExperience { get; set; }

		/// <summary>
		/// сведения о стаже работы педагогического
		/// работника по специальности
		/// </summary>
		[JsonProperty("specExperience")]
		public string SpecExperience { get; set; }

		/// <summary>
		/// id кабинета преподавателя
		/// </summary>
		[JsonProperty("proId")]
		public string ProId { get; set; }

		[JsonProperty("branch")]
		public string Branch { get; set; }
	}

}
