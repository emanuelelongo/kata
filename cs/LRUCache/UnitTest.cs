using System;
using System.Collections.Generic;
using Xunit;

namespace LRUCache
{
    public class UnitTest
    {
        public List<IOperation[]> operationsSet;
        public UnitTest()
        {
            operationsSet = new List<IOperation[]> {
                new IOperation[]{ 
                    new Put(1, 1),
                    new Put(2, 2),
                    new Get(1).Expect(1),
                    new Put(3, 3),
                    new Get(2).Expect(-1),
                    new Put(4, 4),
                    new Get(1).Expect(-1),
                    new Get(3).Expect(3),
                    new Get(4).Expect(4)
                },
                new IOperation[]{ 
                    new Put(1, 1),
                    new Put(2, 2),
                    new Get(1).Expect(-1),
                    new Put(3, 3),
                    new Get(2).Expect(-1),
                    new Put(4, 4),
                    new Get(1).Expect(-1),
                    new Get(3).Expect(-1),
                    new Get(4).Expect(4)
                },
                new IOperation[]{ 
                    new Put(1, 1),
                    new Put(2, 2),
                    new Get(1).Expect(1),
                    new Put(3, 3),
                    new Get(2).Expect(2),
                    new Put(4, 4),
                    new Get(1).Expect(1),
                    new Get(3).Expect(3),
                    new Get(4).Expect(4)
                },
            };
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(1, 1)]
        [InlineData(2, 10)]
        public void Test(int set, int capacity)
        {
            var cache = new LRUCache(capacity);
            var lastResult = 0;
            foreach(var op in operationsSet[set]) {
                lastResult = op.Execute(cache);
            }
        }
    }

    public interface IOperation
    {
        int Execute(LRUCache cache);
    }

    public class Get : IOperation
    {
        public int Key { get; set; }
        private int? expectedValue;
        public Get(int key) 
        {
            this.Key = key;
        }

        public Get Expect(int n)
        {
            this.expectedValue = n;
            return this;
        }

        public int Execute(LRUCache cache)
        {
            var returnValue = cache.Get(this.Key);
            if(expectedValue.HasValue)
                Assert.Equal(expectedValue, returnValue);
            return returnValue;
        }
    }

    public class Put : IOperation
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public Put(int key, int value)
        {
            this.Key = key;
            this.Value = value;
        }
        public int Execute(LRUCache cache)
        {
            cache.Put(this.Key, this.Value);
            return 0;
        }
    }
}
