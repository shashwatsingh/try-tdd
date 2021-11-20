// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Xunit;

// namespace QuizApp.Core.Tests;

// public class CollectionTests
// {
//     // [Fact]
//     // public void ShouldCreateNewQuiz()
//     // {
//     //     // var sut = new QuizManager();
//     //     // var quiz = new Quiz
//     //     // {
//     //     //     Name = "Q1",
//     //     //     Questions = 
//     //     // };

//     //     // sut.CreateQuiz();

//     //     // object equality
//     //     var o1 = new C1("val");
//     //     var o2 = new C1("val");
//     //     Assert.True(o1 == o2);
//     //     Assert.True(o2 == o1);
//     //     Assert.True(o1.Equals(o2));

//     // }

//     [Fact]
//     public void CollectionEquality()
//     {
//         //Given
//         var items = new HashSet<C1>
//         {
//             new C1("A"),
//             new C1("A"),
//             new C1("B"),
//         };

//         //Then
//         Assert.False(items.Add(new C1("A")));
//     }

//     [Fact]
//     public void RecordsWorkForIdentity()
//     {
//         //Given
//         var o1 = new C2("val");
//         var o2 = new C2("val");

//         //When
//         var result = o1 == o2;

//         //Then
//         Assert.True(result);

//         var set = new HashSet<C2>();
//         Assert.True(set.Add(new C2("val")));
//         Assert.False(set.Add(new C2("val")));
//     }

//     [Fact]
//     public void ClassesWorkForIdentity()
//     {
//         //Given
//         var o1 = new C3("val");
//         var o2 = new C3("val");

//         //When
//         var result = o1 == o2;

//         //Then
//         Assert.True(result);

//         var set = new HashSet<C3>();
//         Assert.True(set.Add(new C3("val")));
//         Assert.False(set.Add(new C3("val")));
//     }
// }


// public record C2(string P1);

// public class C3 //: IEquatable<C1>
// {
//     public C3(string p1) { this.P1 = p1; }

//     public string P1 { get; set; }

    
//     public static bool operator ==(C3 obj1, C3 obj2) => obj1.P1 == obj2.P1;

//     public static bool operator !=(C3 obj1, C3 obj2) => obj1.P1 != obj2.P1;
// }

// public class C1 //: IEquatable<C1>
// {
//     public C1() { }
//     public C1(string p1) { this.P1 = p1; }

//     public string? P1 { get; set; }

//     public bool Equals(C1? other)
//     {
//         if (other == null) return false;
//         if (string.IsNullOrEmpty(other.P1)) return false;

//         return other.P1 == this.P1;
//     }

//     public override int GetHashCode()
//     {
//         return P1?.GetHashCode() ?? "".GetHashCode();
//     }

//     public override string ToString()
//     {
//         return "P1=" + this.P1 ?? "<null>";
//     }

//     public override bool Equals(object? obj)
//     {
//         if (obj is not C1) return false;
//         return this.Equals((C1)obj);
//     }

//     public static bool operator ==(C1 obj1, C1 obj2) => Equals(obj1, obj2);

//     public static bool operator !=(C1 obj1, C1 obj2) => !Equals(obj1, obj2);
// }