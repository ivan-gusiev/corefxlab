﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime;
using System.Runtime.CompilerServices;

namespace System.Binary
{
    /// <summary>
    /// Reads bytes as primitives with specific endianness
    /// </summary>
    /// <remarks>
    /// For native formats, SpanExtensions.Read<T> should be used.
    /// Use these helpers when you need to read specific endinanness.
    /// </remarks>
    public static class BufferReader
    {
        /// <summary>
        /// Reads a structure of type <typeparamref name="T"/> out of a span of bytes.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ReadBigEndian<[Primitive]T>(this ReadOnlySpan<byte> span) where T : struct
            => BitConverter.IsLittleEndian ? UnsafeUtilities.Reverse(span.Read<T>()) : span.Read<T>();

        /// <summary>
        /// Reads a structure of type <typeparamref name="T"/> out of a span of bytes.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ReadLittleEndian<[Primitive]T>(this ReadOnlySpan<byte> span) where T : struct
            => BitConverter.IsLittleEndian ? span.Read<T>() : UnsafeUtilities.Reverse(span.Read<T>());

        /// <summary>
        /// Reads a structure of type <typeparamref name="T"/> out of a span of bytes.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ReadBigEndian<[Primitive]T>(this Span<byte> span) where T : struct
            => BitConverter.IsLittleEndian ? UnsafeUtilities.Reverse(span.Read<T>()) : span.Read<T>();

        /// <summary>
        /// Reads a structure of type <typeparamref name="T"/> out of a span of bytes.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ReadLittleEndian<[Primitive]T>(this Span<byte> span) where T : struct
            => BitConverter.IsLittleEndian ? span.Read<T>() : UnsafeUtilities.Reverse(span.Read<T>());
    }
}