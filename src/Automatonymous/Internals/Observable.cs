// Copyright 2007-2014 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Automatonymous.Internals
{
    using System;


    class Observable<T> :
        Connectable<IObserver<T>>,
        IObservable<T>,
        IObserver<T>
    {
        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (observer == null)
                throw new ArgumentNullException("observer");

            return base.Connect(observer);
        }

        public void OnNext(T value)
        {
            ForEach(x => x.OnNext(value));
        }

        public void OnError(Exception exception)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");

            ForEach(x => x.OnError(exception));
        }

        public void OnCompleted()
        {
            ForEach(x => x.OnCompleted());
        }
    }
}