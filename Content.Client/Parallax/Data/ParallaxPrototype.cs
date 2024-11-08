using Robust.Shared.Prototypes;
using Robust.Shared.Maths;
using System;
using System.Numerics;
using Robust.Client;
using Robust.Client.State;
using Robust.Shared.IoC;
using Robust.Shared.Serialization.Manager.Attributes;
using System.Collections.Generic;

namespace Content.Client.Parallax.Data;

/// <summary>
/// Prototype data for a parallax.
/// </summary>
[Prototype("parallax")]
public sealed partial class ParallaxPrototype : IPrototype
{
    /// <inheritdoc/>
    [IdDataField]
    public string ID { get; private set; } = default!;

    /// <summary>
    /// Parallax layers.
    /// </summary>
    [DataField("layers")]
    public List<ParallaxLayerConfig> Layers { get; private set; } = new();

    /// <summary>
    /// Parallax layers, low-quality.
    /// </summary>
    [DataField("layersLQ")]
    public List<ParallaxLayerConfig> LayersLQ { get; private set; } = new();

    /// <summary>
    /// If low-quality layers don't exist for this parallax and high-quality should be used instead.
    /// </summary>
    [DataField("layersLQUseHQ")]
    public bool LayersLQUseHQ { get; private set; } = true;
}
