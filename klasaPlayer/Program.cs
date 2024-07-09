using klasaPlayer;

test1();Console.WriteLine();
test2();Console.WriteLine();
test3();Console.WriteLine();
test4();Console.WriteLine();
test5();Console.WriteLine();
test6();

void test1()
{
    // Test: poprawne tworzenie obiektu Player, dane poprawne
    //       typowe czynności poprawne
    Player p = new Player(name: "storozhuk",
                          password: "AbCd#123!");
    p.AddScore(22);
    p.AddScore(41);
    Console.WriteLine(p);
    p.Name = "ysto9";
    p.ChangePassword(oldPassword: "AbCd#123!",
                     newPassword: "a123*!BC");
    Console.WriteLine(p.TryAddScore(32));
    Console.WriteLine(p);
}

void test2()
{
    // Test: poprawne zainicjowanie obiektu Player, dane poprawne
    Player p = new Player(name: "storozhuk", password: "AbCd#123!");
    Console.WriteLine(p);
}

void test3()
{
    // Test: tworzenie obiektu Player, name do skorygowania,
    // spacje w środku, białe znaki na początku i końcu, wielkość liter
    Player p = new Player(name: "  Storozhuk", password: "AbCd#123!");
    Console.WriteLine(p);
    Player p1 = new Player(name: "Storozhuk   ", password: "AbCd#123!");
    Console.WriteLine(p1);
    Player p2 = new Player(name: "Sto Roz  Huk", password: "AbCd#123!");
    Console.WriteLine(p2);
}

void test4()
{
    // Test: błędne hasło, długość hasła
    try
    {
        Player p = new Player(name: "sto123", password: null);
        Console.WriteLine(p);
        Player p1 = new Player(name: "sto123", password: "AbCd#");
        Console.WriteLine(p1);
        Player p2 = new Player(name: "sto123", password: "AbCdef#0123456789");
        Console.WriteLine(p2);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void test5()
{
    // Test: metoda ChangePassword()
    Player p = new Player(name: "sto123", password: "p0prawne Hasl0!");
    Console.WriteLine(p.ChangePassword(oldPassword: "p0prawne Hasl0!",
                                       newPassword: "brakCyfr?"));
    Console.WriteLine(p.ChangePassword(oldPassword: "p0prawne Hasl0!",
                                       newPassword: "102938475"));
    Console.WriteLine(p.ChangePassword(oldPassword: "p0prawne Hasl0!",
                                       newPassword: "brakInterpunkcji1"));
    Console.WriteLine(p.ChangePassword(oldPassword: "p0prawne Hasl0!",
                                       newPassword: "spacjaNaKoncu1  "));
    Console.WriteLine(p.ChangePassword(oldPassword: "p0prawne Hasl0!",
                                       newPassword: "brak1duzej-litery"));
    Console.WriteLine(p.ChangePassword(oldPassword: "zleHasl0!",
                                       newPassword: "p0prawneHasl0."));
    Console.WriteLine(p.ChangePassword(oldPassword: "p0prawne Hasl0!",
                                       newPassword: "p0prawneHasl0."));
}

void test6()
{
    // Test: AddScore
    Player p = new Player(name: "sto123", password: "aB12.,aC");
    Console.WriteLine(p);
    try
    {
        p.AddScore(-1);
    }
    catch (ArgumentOutOfRangeException e)
    {
        Console.WriteLine(e.Message);
    }
    try
    {
        p.AddScore(101);
    }
    catch (ArgumentOutOfRangeException e)
    {
        Console.WriteLine(e.Message);
    }
    p.AddScore(100);
    Console.WriteLine(p);
    p.AddScore(0);
    Console.WriteLine(p);
}