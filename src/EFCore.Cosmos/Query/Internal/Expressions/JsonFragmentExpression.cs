// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore.Cosmos.Storage.Internal;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore.Cosmos.Query.Internal;

/// <summary>
///     An expression that represents a JSON fragment.
/// </summary>
/// <remarks>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </remarks>
public class JsonFragmentExpression(string json) : SqlExpression(typeof(string), CosmosTypeMapping.Default)
{
    /// <summary>
    ///     The JSON string token to print in SQL tree.
    /// </summary>
    public virtual string Json { get; } = json;

    /// <inheritdoc />
    protected override Expression VisitChildren(ExpressionVisitor visitor)
        => this;

    /// <inheritdoc />
    protected override void Print(ExpressionPrinter expressionPrinter)
        => expressionPrinter.Append(Json);

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected virtual bool Equals(JsonFragmentExpression other)
        => base.Equals(other)
            && Json == other.Json;

    /// <inheritdoc />
    public override bool Equals(object? obj)
        => !ReferenceEquals(null, obj)
            && (ReferenceEquals(this, obj)
                || obj.GetType() == GetType()
                && Equals((JsonFragmentExpression)obj));

    /// <inheritdoc />
    public override int GetHashCode()
        => HashCode.Combine(base.GetHashCode(), Json);
}
