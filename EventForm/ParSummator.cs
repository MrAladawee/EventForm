using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventForm
{

    public delegate void FinishDelegate(); // Объявление делегата.
                                           // Является типом данных и позволяет сохранить ссылочки на функции.
                                           // Далее создадим событие типа делегата.
                                           // Мы сказали при создании, что у нас есть тип данных, который соответствует функции (void)
                                           // и у неё не будет никаких параметров.
                                           // В целом можем объявлять делегат любого вида (параметры и тип).
    
    public class ParSummator
    {
        private int _maxVal;
        private object locker = new object();
        public long? Result
        {
            get;
            set;
        }

        public event FinishDelegate Finish; // Если мысленно выкинуть "event" то у нас останется:
                                            // Поле класса FinishDelegate (Finish - переменная, FinishDelegate - класс).
                                            // Однако это не совсем переменная, это событие (из-за event).
                                            // Без event мы бы этой переменной могли бы присваивать ссылки на функции.
                                            // Если у нас стоит event, то на самом деле мы
                                            // получаем возможность в эту переменную добавить не одну ссылку, а много (список).

        public event FinishDelegate Progress;

        // Мы можем вызвать ту функцию, которая лежит в Finish там, где она должна сработать.
        // В этом суть делегата.
        // В нашем случае Finish сработает, когда все 8 потоков отработают.

        // Операция присваивания событию некоторое значение - подписка на событие
        public ParSummator(int maxVal)
        {
            _maxVal = maxVal;
        }

        // Метод сумм
        // Тут будем делить на потоки и нужны параллельные потоки
        public void Sum()
        {
            var threadCount = 8; // количество потоков для вычисления суммы
            var counter = 0; // счетчик потоков
            var progressCounter = 1;
            Result = 0; // В случае повторного вызова Sum
                        // чтобы подсчет шел с нуля, а не с прошлых значений
            for (int tn = 0; tn < threadCount; tn++)
            {
                new Thread(tn =>
                {
                    var s = 0L;

                    for (int i = 1 + (int)tn; i <= _maxVal; i += threadCount) // 0 поток начинает с 1 и считает с шагом 8, 1 поток начинает с 2....
                    {
                        s += i;
                        if ( i >= progressCounter * _maxVal / (100 / threadCount))
                        {
                            progressCounter++;
                            // Сдвиг прогресса (нужно снова событие, вызываемое в процессе вычислений)
                            if (Progress != null) Progress();
                            Thread.Sleep(1);
                        }
                    }

                    // Либо до локера вызываем Finish

                    lock (locker)
                    {
                        Result += s;
                        counter++; // отработал поток => counter++

                        // Либо в локере Finish
                        // В классе ParSummator происходит в нужный момент вызов события
                        if (counter == threadCount) Finish();

                    }

                    // Либо после локера Finish

                    //Finish(); Оставлять так нельзя, поскольку первый поток зайдет сюда и вызовет функцию.
                    // Надо проверить, чтобы все потоки завершились.

                }).Start(tn);
            }
            // Тут Finish мы не можем вызвать, результат будет не законченный (нуль).
            // Сюда мы попадем быстро, так как цикл for отработает быстро, а потоки продолжат работать.
            // То есть вызываем внутри потока
        }
    }
}
