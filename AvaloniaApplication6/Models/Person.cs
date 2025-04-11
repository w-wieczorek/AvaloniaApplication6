using System;

namespace AvaloniaApplication6.Models;

public class Person
{
    public Int64 Id { get; set; }
    public Int64 Id_cond { get; set; }
    public string DtLastModified { get; set; }
    public Int64 BIsDeleted { get; set; }

    public Person(Int64 id , Int64 id_cond, string dtLastModified, Int64 bIsDeleted)
    {
        Id = id;
        Id_cond = id_cond;
        DtLastModified = dtLastModified;
        BIsDeleted = bIsDeleted;
    }
}
