int Sum(int a,int b)  // ورودی و خروجی داشته باشد 
    {
        return (a + b);
    }

Console.WriteLine(Sum(5,6));

//-------------------------------------------
void PrintOnlySalam()  // ورودی و خروجی نداشته باشد
    {
        Console.WriteLine("Salam");
    }
PrintOnlySalam();
//-------------------------------------------

void Print(string text)  // ورودی داشته باشد ولی خروجی نداشته باشد 
    {
        Console.WriteLine(text);
    }
Print("Salam Ostad !");

//-------------------------------------------

String PrintReturn() // خروجی داشته باشد ولی ورودی نداشته باشد 
{
    return "Doroud !";
}

Console.WriteLine(PrintReturn());

//-------------------------------------------

void PrintNumbers(int a) //  تابع بازگشتی
{  
    if (a > 0)
    {
        Console.WriteLine(a);
        PrintNumbers(a - 1);
    }
}
PrintNumbers(5);

//-------------------------------------------

string Names(params string []names) // تعدادی اسم میگیره و به صورت حداگانه نمایش بده
{
    return string.Join(", ", names);
}

Console.WriteLine(Names("ali", "reza",  "mamad", "javad"));

//-------------------------------------------