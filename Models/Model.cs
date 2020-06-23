using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;
using System.Text.Json.Serialization;

//https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=visual-studio
//https://docs.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations

namespace ExpensasAbbinatura.Models
{
    public class ExpensasContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<InstallmentConcept> InstallmentConcepts { get; set; }
        public DbSet<Concept> Concepts { get; set; }
        public DbSet<ConceptType> ConceptTypes { get; set; }
        public DbSet<Building> Buildings { get; set; }

        public ExpensasContext(DbContextOptions<ExpensasContext> options) : base(options) { }
    }

    public class Building
    {
        public int BuildingID { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
    }

    public class Person
    {
        public int PersonID { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Building Building { get; set; }
        public List<Installment> Installments { get; } = new List<Installment>();
    }

    public class InstallmentStatus
    {
        public string InstallmentStatusID { get; set; }
        public string Description { get; set; }
    }

    public class Installment
    {
        public int InstallmentID { get; set; }
        public Person Person { get; set; }
        public DateTime When { get; set; }
        public InstallmentStatus Status { get; set; }
        public List<InstallmentConcept> InstallmentConcepts { get; } = new List<InstallmentConcept>();

        [ScaffoldColumn(false)]
        public string InstallmentConceptsJSON
        { 
            get
            {
                return JsonSerializer.Serialize(new
                {
                    Total,
                    InstallmentConcepts = InstallmentConcepts.OrderBy(x => x.Concept.ConceptType.Description).ThenBy(x => x.Concept.Description)
                });
            } 
        }

        [ScaffoldColumn(false)]
        public decimal Total
        {
            get { return InstallmentConcepts.Sum(x => x.Amount); }
        }
    }

    public class InstallmentConcept
    {
        public int InstallmentConceptID { get; set; }
        public Concept Concept { get; set; }
        public decimal Amount { get; set; }
        public string Comments { get; set; }
    }

    public class ConceptType
    {
        public int ConceptTypeID { get; set; }
        [DisplayName("Tipo")]
        public string Description { get; set; }
    }

    public class Concept
    {
        public int ConceptID { get; set; }
        [DisplayName("Concepto")]
        public string Description { get; set; }
        public ConceptType ConceptType { get; set; }
    }
}