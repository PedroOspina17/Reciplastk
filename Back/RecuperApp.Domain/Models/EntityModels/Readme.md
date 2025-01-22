
## Read me - Entity models

This folder reflects the data tables in the database, every change on these files should be followed by a migration to avoid error at runtime. 
To create/modify tables in the database follow the instructions:

1. Add a new class in the EntityModels folder. Remember to always inherith from BaseEntity class (Unless the class is a detail table).
1. Remember to always specify the Primary key
1. If there is any foreign key, always create 2 props. One with the int type and the name should be [ForeignTable]Id, the second property is with the type of the entity and the name should be the same as the entity pointing to.
1. All the fields are not nullable, except for string. If you need them not nullable add the `?` operator to the datatype.
1. For strings that needs to be required add `[Required]` attribute.
1. To add extra restrictions to the field (like max lenght, Ranges on numbers, specific values only, etc) use DataAnnotations attributes. For more information see links bellow: 
 
     * [List of data annotations available](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-9.0). 
     * [Learn about Data Annotations](https://www.bytehide.com/blog/data-annotations-in-csharp).
     * [How to create foreign keys](https://learn.microsoft.com/en-us/ef/core/modeling/relationships)
     * [Learn about EntityFramework](https://learn.microsoft.com/es-es/ef/ef6/modeling/code-first/workflows/new-database)
     * [How to create migrations](https://learn.microsoft.com/es-es/ef/ef6/modeling/code-first/migrations/#generating--running-migrations)

See example of class and properties bellow:

	```C#
		public class Customer : BaseEntity
        {
            [Key] 
            public int Customerid { get; set; } // To create a primary key

            public int Customertypeid { get; set; } 
            public virtual Customertype Customertype { get; set; } // To create a foreign key

            [Required] // Only for strings this attribute is required.
            [StringLength(50)] // Use this attribute to specify the max length 
            public string Nit { get; set; } // To create a required string field with max length of 50

            [StringLength(50)]
            public string Name { get; set; } // This creates a nullable string 
            
            public int Age { get; set; } // To create a not null integer.

            public int? Age { get; set; } // To create a nullable integer. For all types other than string, you need to add '?' to allow nulls.

            public DateTime? Clientsince { get; set; } // Nullable datetime.

            public bool? Needspickup { get; set; } // Nullable boolean.
        }
	```