namespace System
{
    /// <summary>
    /// 采用了 Dispose 模式对托管和非托管资源进行优化处理。建议所有需要使用 <see cref="IDisposable"/> 接口的派生类继承此类，有助于提升性能。
    /// 查看相关文章 https://msdn.microsoft.com/en-us/library/b1yfkh5e(v=vs.110).aspx 以了解 Dispose 模式。
    /// </summary>
    public abstract class DisposableHandler : IDisposable
    {
        /// <summary>
        /// Finalizes an instance of the <see cref="DisposableHandler"/> class.
        /// </summary>
        ~DisposableHandler()
        {
            this.Dispose(false);
        }
        /// <summary>
        /// 执行与释放、释放或重置非托管资源相关的应用程序定义的任务。
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 由子类派生重新定义其执行、释放或重置非托管资源相关的应用程序定义的任务的方式。在没有弄清楚 Dispose 模式之前建议不要重写此方法，以免造成性能的缺失。
        /// 若想在派生类进行资源的释放和处理，请重写 <see cref="DisposeHandler"/> 进行处理。
        /// </summary>
        /// <param name="disposing"><c>true</c> 时由派生类进行资源释放，否则由析构函数进行资源释放。</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.HasDisposed)
            {
                return;
            }

            if (disposing)
            {
                DisposeHandler();
            }

            this.HasDisposed = true;
        }

        /// <summary>
        /// 由派生类执行与释放或重置非托管资源相关的应用程序定义的任务处理。
        /// </summary>
        protected abstract void DisposeHandler();


        /// <summary>
        /// 获取一个布尔值，表示资源是否已经被释放。
        /// </summary>
        /// <value>
        /// 如果资源已被释放，则为 <c>true</c> ；否则为 <c>false</c>.
        /// </value>
        public bool HasDisposed { get; protected set; }
    }
}
