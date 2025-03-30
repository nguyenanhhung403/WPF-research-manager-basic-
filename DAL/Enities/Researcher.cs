using System;
using System.Collections.Generic;

namespace DAL.Enities;

public partial class Researcher
{
    public int ResearcherId { get; set; }

    public string FullName { get; set; } = null!;

    public string Affiliation { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Expertise { get; set; } = null!;

    public virtual ICollection<ResearchProject> ResearchProjects { get; set; } = new List<ResearchProject>();
}
