//
// Copyright (c) 2022-2022 the rbfx project.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
// Based on ComPtr interface by Silk.NET/.NET Foundation
// https://github.com/dotnet/Silk.NET/blob/main/src/Core/Silk.NET.Core/Native/ComPtr%601.cs
//

using Urho3DNet;

namespace SampleProject;

public readonly struct SharedPtr<T>: IDisposable where T: RefCounted
{
    public SharedPtr(T other)
    {
        _value = other;
        AddRef();
    }
    public SharedPtr(SharedPtr<T> other) : this(other._value) { }

    public static implicit operator SharedPtr<T>(T other) => new SharedPtr<T>(other);
    public static implicit operator T(SharedPtr<T> @this) => @this._value;

    private readonly int AddRef()
    {
        return _value?.AddRef() ?? 0;
    }

    public int ReleaseRef()
    {
        return _value?.ReleaseRef() ?? 0;
    }

    public readonly T Get() => _value;

    public void Dispose()
    {
        ReleaseRef();
    }

    private readonly T _value;
}