using System;
using System.Collections;
using System.Transactions;

namespace LinkedList.Model
{
    
    /// <summary>
    /// Односвязный список
    /// </summary>
    public class LinkedList<T> : IEnumerable
    {
        /// <summary>
        /// Первый элемент списка
        /// </summary>
        public Item<T> Head { get; private set; }

        /// <summary>
        /// Последний элемент списка
        /// </summary>
        public Item<T> Tail { get; private set; }

        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Создать пустой список
        /// </summary>
        public LinkedList()
        {
            Clear();
        }

        /// <summary>
        /// Очистить список
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Создать список с начальным элементов
        /// </summary>
        public LinkedList(T data)
        {
            
            SetHeadAndTail(data);

        }

        /// <summary>
        /// Добавить данные в конец списка
        /// </summary>
        public void Add(T data)
        {

            if (Tail != null)
            {
                var item = new Item<T>(data);
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                SetHeadAndTail(data);
            }
        }

        /// <summary>
        /// Удалить первое вхождение данных в список
        /// </summary>
        public void Delete(T data)
        {
            if (Head != null)
            {
                if(Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }

                var current = Head.Next;
                var previous = Head;


                while(current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                    }

                    previous = current;
                    current = current.Next;
                }
            }
            else 
            {
                SetHeadAndTail(data);
            }
        }
        /// <summary>
        /// Добавить данные в начало списка
        /// </summary>
        public void AppendHead(T data)
        {
            var item = new Item<T>(data)
            {
                Next = Head
            };
            
            Head = item;
            Count++;
        }

        public void InsertAfter(T target, T data)
        {
            if (Head != null)
            {
                var item = new Item<T>(data);
                if (Head.Data.Equals(target))
                {
                    item.Next = Head.Next;
                    Head.Next = item;
                    Count++;
                    return;
                }

                var current = Head.Next;
                var previous = Head;


                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                    }

                    previous = current;
                    current = current.Next;
                }
            }
            else 
            {
                //Нужно для себя решить, если список пустой, 
                //то либо не добавлять ничего, либо вставить данные

                SetHeadAndTail(target);
                Add(data);
            }

        }

        private void SetHeadAndTail(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;

        }

        /// <summary>
        /// Получить перечисление всех элементов списка
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
