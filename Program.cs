using System.Threading;

Game game = new Game();
game.Check_in();


public delegate void finish();
class Car
{
    public event finish _Finish;
    protected string _Name;
    protected int _Speed;
    protected int _MaxSpeed;
    public int GetSpeed()
    {
        return _Speed;
    }
    public string GetName()
    {
        return _Name;
    }
    public void SetSpeed(int speed)
    {
        _Speed = speed;
    }

    public int GetMaxSpeed()
    {
        return _MaxSpeed;
    }
    public void Finish()
    {
        Console.WriteLine($"{_Name} финишировал первым!");
    }

    public void SetName(string name)
    {
        _Name = name;
    }
}

class PassengerCar:Car
{
    public event finish _Finish;

    public PassengerCar()
    {
        _Name = "Легковой автомобиль";
        _Speed = 70;
        _MaxSpeed = 250;
    }
    public void Finish()
    {
        Console.WriteLine("Легковой автомобиль финишировал первым!");
    }
    public int GetSpeed()
    {
        return _Speed;
    }
    
    public void SetSpeed(int speed)
    {
        _Speed = speed;
    }
    public int GetMaxSpeed()
    {
        return _MaxSpeed;
    }
    public void SetName(string name)
    {
        _Name = name;
    }

}

class SportCar: Car
{
    public event finish _Finish;
    public SportCar()
    {
        _Name = "Спортивный автомобиль";
        _Speed = 90;
        _MaxSpeed = 300;
    }
    public void Finish()
    {
        Console.WriteLine("Спортивный автомобиль финишировал первым!");
    }
    public int GetSpeed()
    {
        return _Speed;
    }
    public void SetSpeed(int speed)
    {
        _Speed = speed;
    }
    public int GetMaxSpeed()
    {
        return _MaxSpeed;
    }

    public void SetName(string name)
    {
        _Name = name;
    }

}

class Truck:Car
{
    public event finish _Finish;
    public Truck()
    {
        _Name = "Грузовой автомобиль";
        _Speed = 30;
        _MaxSpeed = 150;
    }
    public void Finish()
    {
        Console.WriteLine("Грузовой автомобиль финишировал первым!");
    }
    public int GetSpeed()
    {
        return _Speed;
    }
    public void SetSpeed(int speed)
    {
        _Speed = speed;
    }
    public int GetMaxSpeed()
    {
        return _MaxSpeed;
    }
    public void SetName(string name)
    {
        _Name = name;
    }


}

class Bus : Car
{
    public event finish _Finish;
    public Bus()
    {
        _Name = "Автобус";
        _Speed = 50;
        _MaxSpeed = 170;
    }

    public void Finish()
    {
        Console.WriteLine("Автобус финишировал первым!");
    }
    public int GetSpeed()
    {
        return _Speed;
    }
    public void SetSpeed(int speed)
    {
        _Speed = speed;
    }
    public int GetMaxSpeed()
    {
        return _MaxSpeed;
    }
    public void SetName(string name)
    {
        _Name = name;
    }

}

class Game
{
    Car _Car1;
    Car _Car2;

    public Game()
    {
        string car1 = "";
        string car2 = "";
        Console.WriteLine("Выберите машины которые будут учавствовать в заезде");
        Console.WriteLine(" 1- Легковой автомобиль\n 2- Спортивный автомобиль\n 3- Грузовой автомобиль\n 4- Автобус");
        car1 = Console.ReadLine();
        Console.WriteLine("\nВыберите соперника этому автомобилю\n");
        car2 = Console.ReadLine();

        if (car1 == "1")
        {
            _Car1 = new PassengerCar();
        }
        if (car1 == "2")
        {
            _Car1 = new SportCar();
        }
        if (car1 == "3")
        {
            _Car1 = new Truck();
        }
        if (car1 == "4")
        {
            _Car1 = new Bus();
        }

        if (car2 == "1")
        {
            if(car1=="1")
            {
                _Car2 = new PassengerCar();
                _Car2.SetName(_Car2.GetName() + "1");
            }
            else
            {
                _Car2 = new PassengerCar();
            }
        }
        if (car2 == "2")
        {
            if (car1 == "2")
            {
                _Car2 = new SportCar();
                _Car2.SetName(_Car2.GetName() + "1");
            }
            else
            {
                _Car2 = new SportCar();
            }
        }
        if (car2 == "3")
        {
            if (car1 == "3")
            {
                _Car2 = new Truck();
                _Car2.SetName(_Car2.GetName() + "1");
            }
            else
            {
                _Car2 = new Truck();
            }
        }
        if (car2 == "4")
        {
            if (car1 == "4")
            {
                _Car2 = new Bus();
                _Car2.SetName(_Car2.GetName() + "1");
            }
            else
            {
                _Car2 = new Bus();
            }
        }

    }

    public void Check_in()
    {
        Console.WriteLine($"В заезде учавствуют {_Car1.GetName()} и {_Car2.GetName()}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nНа Старт!\n");
        Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nВнимание!\n");
        Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n Поехали!\n");
        Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.White;

        int time = 0;
        for (int i = 0; i <= 100; i++)
        {
            time++;
            if (100 - (_Car1.GetSpeed() * time / 100) <= 0)
            {
                _Car1._Finish += _Car1.Finish;
                _Car1.Finish();
                break;
            }
            if (100 - (_Car2.GetSpeed() * time / 100) <= 0)
            {
                _Car2._Finish += _Car2.Finish;
                _Car2.Finish();

                break;
            }

            Console.WriteLine($"Скорость {_Car1.GetName()} = {_Car1.GetSpeed()} км.ч (Расстояние до финиша: {100-(_Car1.GetSpeed() * time/100)})");
            Console.WriteLine($"Скорость {_Car2.GetName()} = {_Car2.GetSpeed()} км.ч (Расстояние до финиша: {100-(_Car2.GetSpeed() * time/100)})");
            Thread.Sleep(1000);
            if (_Car1.GetSpeed() < _Car1.GetMaxSpeed())
            {
                if (_Car1.GetSpeed() > _Car2.GetSpeed())
                {
                    _Car1.SetSpeed(_Car1.GetSpeed() + 10);
                }
                else
                {
                    _Car1.SetSpeed(_Car1.GetSpeed() + 5);
                }
            }
            if (_Car2.GetSpeed() < _Car2.GetMaxSpeed())
            {
                if (_Car2.GetSpeed() > _Car1.GetSpeed())
                {
                    _Car2.SetSpeed(_Car2.GetSpeed() + 10);
                }
                else
                {
                    _Car2.SetSpeed(_Car2.GetSpeed() + 5);
                }
            }


        }
    }
}