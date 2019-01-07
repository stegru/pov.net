namespace PovScene.SceneDescription
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Output;

    /// <summary>A povray keyword.</summary>
    public enum Keyword
    {
        /// <summary>An undefined keyword (not a keyword).</summary>
        [Keyword("")] Undefined,

        /// <summary>No keyword (not a keyword).</summary>
        [Keyword("")] Null,

        /// <summary>"aa_level" keyword.</summary>
        [Keyword("aa_level")] AaLevel,

        /// <summary>"aa_threshold" keyword.</summary>
        [Keyword("aa_threshold")] AaThreshold,

        /// <summary>"absorption" keyword.</summary>
        [Keyword("absorption")] Absorption,

        /// <summary>"abs" keyword.</summary>
        [Keyword("abs")] Abs,

        /// <summary>"accuracy" keyword.</summary>
        [Keyword("accuracy")] Accuracy,

        /// <summary>"acos" keyword.</summary>
        [Keyword("acos")] Acos,

        /// <summary>"acosh" keyword.</summary>
        [Keyword("acosh")] Acosh,

        /// <summary>"adaptive" keyword.</summary>
        [Keyword("adaptive")] Adaptive,

        /// <summary>"adc_bailout" keyword.</summary>
        [Keyword("adc_bailout")] AdcBailout,

        /// <summary>"agate" keyword.</summary>
        [Keyword("agate")] Agate,

        /// <summary>"agate_turb" keyword.</summary>
        [Keyword("agate_turb")] AgateTurb,

        /// <summary>"albedo" keyword.</summary>
        [Keyword("albedo")] Albedo,

        /// <summary>"all" keyword.</summary>
        [Keyword("all")] All,

        /// <summary>"all_intersections" keyword.</summary>
        [Keyword("all_intersections")] AllIntersections,

        /// <summary>"alpha" keyword.</summary>
        [Keyword("alpha")] Alpha,

        /// <summary>"altitude" keyword.</summary>
        [Keyword("altitude")] Altitude,

        /// <summary>"always_sample" keyword.</summary>
        [Keyword("always_sample")] AlwaysSample,

        /// <summary>"ambient" keyword.</summary>
        [Keyword("ambient")] Ambient,

        /// <summary>"ambient_light" keyword.</summary>
        [Keyword("ambient_light")] AmbientLight,

        /// <summary>"angle" keyword.</summary>
        [Keyword("angle")] Angle,

        /// <summary>"anisotropy" keyword.</summary>
        [Keyword("anisotropy")] Anisotropy,

        /// <summary>"aoi" keyword.</summary>
        [Keyword("aoi")] Aoi,

        /// <summary>"aperture" keyword.</summary>
        [Keyword("aperture")] Aperture,

        /// <summary>"append" keyword.</summary>
        [Keyword("append")] Append,

        /// <summary>"arc_angle" keyword.</summary>
        [Keyword("arc_angle")] ArcAngle,

        /// <summary>"area_illumination" keyword.</summary>
        [Keyword("area_illumination")] AreaIllumination,

        /// <summary>"area_light" keyword.</summary>
        [Keyword("area_light")] AreaLight,

        /// <summary>"array" keyword.</summary>
        [Keyword("array")] Array,

        /// <summary>"asc" keyword.</summary>
        [Keyword("asc")] Asc,

        /// <summary>"ascii" keyword.</summary>
        [Keyword("ascii")] Ascii,

        /// <summary>"asin" keyword.</summary>
        [Keyword("asin")] Asin,

        /// <summary>"asinh" keyword.</summary>
        [Keyword("asinh")] Asinh,

        /// <summary>"assumed_gamma" keyword.</summary>
        [Keyword("assumed_gamma")] AssumedGamma,

        /// <summary>"atan" keyword.</summary>
        [Keyword("atan")] Atan,

        /// <summary>"atan2" keyword.</summary>
        [Keyword("atan2")] Atan2,

        /// <summary>"atanh" keyword.</summary>
        [Keyword("atanh")] Atanh,

        /// <summary>"autostop" keyword.</summary>
        [Keyword("autostop")] Autostop,

        /// <summary>"average" keyword.</summary>
        [Keyword("average")] Average,

        /// <summary>"background" keyword.</summary>
        [Keyword("background")] Background,

        /// <summary>"bezier_spline" keyword.</summary>
        [Keyword("bezier_spline")] BezierSpline,

        /// <summary>"bicubic_patch" keyword.</summary>
        [Keyword("bicubic_patch")] BicubicPatch,

        /// <summary>"bitwise_and" keyword.</summary>
        [Keyword("bitwise_and")] BitwiseAnd,

        /// <summary>"bitwise_or" keyword.</summary>
        [Keyword("bitwise_or")] BitwiseOr,

        /// <summary>"bitwise_xor" keyword.</summary>
        [Keyword("bitwise_xor")] BitwiseXor,

        /// <summary>"black_hole" keyword.</summary>
        [Keyword("black_hole")] BlackHole,

        /// <summary>"blend_gamma" keyword.</summary>
        [Keyword("blend_gamma")] BlendGamma,

        /// <summary>"blend_mode" keyword.</summary>
        [Keyword("blend_mode")] BlendMode,

        /// <summary>"blob" keyword.</summary>
        [Keyword("blob")] Blob,

        /// <summary>"blue" keyword.</summary>
        [Keyword("blue")] Blue,

        /// <summary>"blur_samples" keyword.</summary>
        [Keyword("blur_samples")] BlurSamples,

        /// <summary>"bmp" keyword.</summary>
        [Keyword("bmp")] Bmp,

        /// <summary>"bokeh" keyword.</summary>
        [Keyword("bokeh")] Bokeh,

        /// <summary>"bounded_by" keyword.</summary>
        [Keyword("bounded_by")] BoundedBy,

        /// <summary>"box" keyword.</summary>
        [Keyword("box")] Box,

        /// <summary>"boxed" keyword.</summary>
        [Keyword("boxed")] Boxed,

        /// <summary>"bozo" keyword.</summary>
        [Keyword("bozo")] Bozo,

        /// <summary>"b_spline" keyword.</summary>
        [Keyword("b_spline")] BSpline,

        /// <summary>"break" keyword.</summary>
        [Keyword("break")] Break,

        /// <summary>"brick" keyword.</summary>
        [Keyword("brick")] Brick,

        /// <summary>"brick_size" keyword.</summary>
        [Keyword("brick_size")] BrickSize,

        /// <summary>"brightness" keyword.</summary>
        [Keyword("brightness")] Brightness,

        /// <summary>"brilliance" keyword.</summary>
        [Keyword("brilliance")] Brilliance,

        /// <summary>"bt2020" keyword.</summary>
        [Keyword("bt2020")] Bt2020,

        /// <summary>"bt709" keyword.</summary>
        [Keyword("bt709")] Bt709,

        /// <summary>"bump_map" keyword.</summary>
        [Keyword("bump_map")] BumpMap,

        /// <summary>"bump_size" keyword.</summary>
        [Keyword("bump_size")] BumpSize,

        /// <summary>"bumps" keyword.</summary>
        [Keyword("bumps")] Bumps,

        /// <summary>"camera" keyword.</summary>
        [Keyword("camera")] Camera,

        /// <summary>"case" keyword.</summary>
        [Keyword("case")] Case,

        /// <summary>"caustics" keyword.</summary>
        [Keyword("caustics")] Caustics,

        /// <summary>"ceil" keyword.</summary>
        [Keyword("ceil")] Ceil,

        /// <summary>"cells" keyword.</summary>
        [Keyword("cells")] Cells,

        /// <summary>"charset" keyword.</summary>
        [Keyword("charset")] Charset,

        /// <summary>"checker" keyword.</summary>
        [Keyword("checker")] Checker,

        /// <summary>"chr" keyword.</summary>
        [Keyword("chr")] Chr,

        /// <summary>"circular" keyword.</summary>
        [Keyword("circular")] Circular,

        /// <summary>"clipped_by" keyword.</summary>
        [Keyword("clipped_by")] ClippedBy,

        /// <summary>"clock" keyword.</summary>
        [Keyword("clock")] Clock,

        /// <summary>"clock_on" keyword.</summary>
        [Keyword("clock_on")] ClockOn,

        /// <summary>"collect" keyword.</summary>
        [Keyword("collect")] Collect,

        /// <summary>"color" keyword.</summary>
        [Keyword("color")] Color,

        /// <summary>"color_map" keyword.</summary>
        [Keyword("color_map")] ColorMap,

        /// <summary>"component" keyword.</summary>
        [Keyword("component")] Component,

        /// <summary>"composite" keyword.</summary>
        [Keyword("composite")] Composite,

        /// <summary>"concat" keyword.</summary>
        [Keyword("concat")] Concat,

        /// <summary>"cone" keyword.</summary>
        [Keyword("cone")] Cone,

        /// <summary>"confidence" keyword.</summary>
        [Keyword("confidence")] Confidence,

        /// <summary>"conic_sweep" keyword.</summary>
        [Keyword("conic_sweep")] ConicSweep,

        /// <summary>"conserve_energy" keyword.</summary>
        [Keyword("conserve_energy")] ConserveEnergy,

        /// <summary>"contained_by" keyword.</summary>
        [Keyword("contained_by")] ContainedBy,

        /// <summary>"control0" keyword.</summary>
        [Keyword("control0")] Control0,

        /// <summary>"control1" keyword.</summary>
        [Keyword("control1")] Control1,

        /// <summary>"coords" keyword.</summary>
        [Keyword("coords")] Coords,

        /// <summary>"cos" keyword.</summary>
        [Keyword("cos")] Cos,

        /// <summary>"cosh" keyword.</summary>
        [Keyword("cosh")] Cosh,

        /// <summary>"count" keyword.</summary>
        [Keyword("count")] Count,

        /// <summary>"crackle" keyword.</summary>
        [Keyword("crackle")] Crackle,

        /// <summary>"crand" keyword.</summary>
        [Keyword("crand")] Crand,

        /// <summary>"cube" keyword.</summary>
        [Keyword("cube")] Cube,

        /// <summary>"cubic" keyword.</summary>
        [Keyword("cubic")] Cubic,

        /// <summary>"cubic_spline" keyword.</summary>
        [Keyword("cubic_spline")] CubicSpline,

        /// <summary>"cubic_wave" keyword.</summary>
        [Keyword("cubic_wave")] CubicWave,

        /// <summary>"cutaway_textures" keyword.</summary>
        [Keyword("cutaway_textures")] CutawayTextures,

        /// <summary>"cylinder" keyword.</summary>
        [Keyword("cylinder")] Cylinder,

        /// <summary>"cylindrical" keyword.</summary>
        [Keyword("cylindrical")] Cylindrical,

        /// <summary>"datetime" keyword.</summary>
        [Keyword("datetime")] Datetime,

        /// <summary>"debug" keyword.</summary>
        [Keyword("debug")] Debug,

        /// <summary>"declare" keyword.</summary>
        [Keyword("declare")] Declare,

        /// <summary>"default" keyword.</summary>
        [Keyword("default")] Default,

        /// <summary>"defined" keyword.</summary>
        [Keyword("defined")] Defined,

        /// <summary>"degrees" keyword.</summary>
        [Keyword("degrees")] Degrees,

        /// <summary>"density" keyword.</summary>
        [Keyword("density")] Density,

        /// <summary>"density_file" keyword.</summary>
        [Keyword("density_file")] DensityFile,

        /// <summary>"density_map" keyword.</summary>
        [Keyword("density_map")] DensityMap,

        /// <summary>"dents" keyword.</summary>
        [Keyword("dents")] Dents,

        /// <summary>"deprecated" keyword.</summary>
        [Keyword("deprecated")] Deprecated,

        /// <summary>"df3" keyword.</summary>
        [Keyword("df3")] Df3,

        /// <summary>"dictionary" keyword.</summary>
        [Keyword("dictionary")] Dictionary,

        /// <summary>"difference" keyword.</summary>
        [Keyword("difference")] Difference,

        /// <summary>"diffuse" keyword.</summary>
        [Keyword("diffuse")] Diffuse,

        /// <summary>"dimension_size" keyword.</summary>
        [Keyword("dimension_size")] DimensionSize,

        /// <summary>"dimensions" keyword.</summary>
        [Keyword("dimensions")] Dimensions,

        /// <summary>"direction" keyword.</summary>
        [Keyword("direction")] Direction,

        /// <summary>"disc" keyword.</summary>
        [Keyword("disc")] Disc,

        /// <summary>"dispersion" keyword.</summary>
        [Keyword("dispersion")] Dispersion,

        /// <summary>"dispersion_samples" keyword.</summary>
        [Keyword("dispersion_samples")] DispersionSamples,

        /// <summary>"dist_exp" keyword.</summary>
        [Keyword("dist_exp")] DistExp,

        /// <summary>"distance" keyword.</summary>
        [Keyword("distance")] Distance,

        /// <summary>"div" keyword.</summary>
        [Keyword("div")] Div,

        /// <summary>"double_illuminate" keyword.</summary>
        [Keyword("double_illuminate")] DoubleIlluminate,

        /// <summary>"dtag" keyword.</summary>
        [Keyword("dtag")] Dtag,

        /// <summary>"eccentricity" keyword.</summary>
        [Keyword("eccentricity")] Eccentricity,

        /// <summary>"else" keyword.</summary>
        [Keyword("else")] Else,

        /// <summary>"elseif" keyword.</summary>
        [Keyword("elseif")] Elseif,

        /// <summary>"emission" keyword.</summary>
        [Keyword("emission")] Emission,

        /// <summary>"end" keyword.</summary>
        [Keyword("end")] End,

        /// <summary>"error" keyword.</summary>
        [Keyword("error")] Error,

        /// <summary>"error_bound" keyword.</summary>
        [Keyword("error_bound")] ErrorBound,

        /// <summary>"evaluate" keyword.</summary>
        [Keyword("evaluate")] Evaluate,

        /// <summary>"exp" keyword.</summary>
        [Keyword("exp")] Exp,

        /// <summary>"expand_thresholds" keyword.</summary>
        [Keyword("expand_thresholds")] ExpandThresholds,

        /// <summary>"exponent" keyword.</summary>
        [Keyword("exponent")] Exponent,

        /// <summary>"exr" keyword.</summary>
        [Keyword("exr")] Exr,

        /// <summary>"exterior" keyword.</summary>
        [Keyword("exterior")] Exterior,

        /// <summary>"extinction" keyword.</summary>
        [Keyword("extinction")] Extinction,

        /// <summary>"face_indices" keyword.</summary>
        [Keyword("face_indices")] FaceIndices,

        /// <summary>"facets" keyword.</summary>
        [Keyword("facets")] Facets,

        /// <summary>"fade_color" keyword.</summary>
        [Keyword("fade_color")] FadeColor,

        /// <summary>"fade_distance" keyword.</summary>
        [Keyword("fade_distance")] FadeDistance,

        /// <summary>"fade_power" keyword.</summary>
        [Keyword("fade_power")] FadePower,

        /// <summary>"falloff" keyword.</summary>
        [Keyword("falloff")] Falloff,

        /// <summary>"falloff_angle" keyword.</summary>
        [Keyword("falloff_angle")] FalloffAngle,

        /// <summary>"false" keyword.</summary>
        [Keyword("false")] False,

        /// <summary>"fclose" keyword.</summary>
        [Keyword("fclose")] Fclose,

        /// <summary>"file_exists" keyword.</summary>
        [Keyword("file_exists")] FileExists,

        /// <summary>"filter" keyword.</summary>
        [Keyword("filter")] Filter,

        /// <summary>"finish" keyword.</summary>
        [Keyword("finish")] Finish,

        /// <summary>"fisheye" keyword.</summary>
        [Keyword("fisheye")] Fisheye,

        /// <summary>"flatness" keyword.</summary>
        [Keyword("flatness")] Flatness,

        /// <summary>"flip" keyword.</summary>
        [Keyword("flip")] Flip,

        /// <summary>"floor" keyword.</summary>
        [Keyword("floor")] Floor,

        /// <summary>"focal_point" keyword.</summary>
        [Keyword("focal_point")] FocalPoint,

        /// <summary>"fog" keyword.</summary>
        [Keyword("fog")] Fog,

        /// <summary>"fog_alt" keyword.</summary>
        [Keyword("fog_alt")] FogAlt,

        /// <summary>"fog_offset" keyword.</summary>
        [Keyword("fog_offset")] FogOffset,

        /// <summary>"fog_type" keyword.</summary>
        [Keyword("fog_type")] FogType,

        /// <summary>"fopen" keyword.</summary>
        [Keyword("fopen")] Fopen,

        /// <summary>"for" keyword.</summary>
        [Keyword("for")] For,

        /// <summary>"form" keyword.</summary>
        [Keyword("form")] Form,

        /// <summary>"frequency" keyword.</summary>
        [Keyword("frequency")] Frequency,

        /// <summary>"fresnel" keyword.</summary>
        [Keyword("fresnel")] Fresnel,

        /// <summary>"function" keyword.</summary>
        [Keyword("function")] Function,

        /// <summary>"gamma" keyword.</summary>
        [Keyword("gamma")] Gamma,

        /// <summary>"gather" keyword.</summary>
        [Keyword("gather")] Gather,

        /// <summary>"gif" keyword.</summary>
        [Keyword("gif")] Gif,

        /// <summary>"global" keyword.</summary>
        [Keyword("global")] Global,

        /// <summary>"global_lights" keyword.</summary>
        [Keyword("global_lights")] GlobalLights,

        /// <summary>"global_settings" keyword.</summary>
        [Keyword("global_settings")] GlobalSettings,

        /// <summary>"gradient" keyword.</summary>
        [Keyword("gradient")] Gradient,

        /// <summary>"granite" keyword.</summary>
        [Keyword("granite")] Granite,

        /// <summary>"gray" keyword.</summary>
        [Keyword("gray")] Gray,

        /// <summary>"gray_threshold" keyword.</summary>
        [Keyword("gray_threshold")] GrayThreshold,

        /// <summary>"green" keyword.</summary>
        [Keyword("green")] Green,

        /// <summary>"hdr" keyword.</summary>
        [Keyword("hdr")] Hdr,

        /// <summary>"height_field" keyword.</summary>
        [Keyword("height_field")] HeightField,

        /// <summary>"hexagon" keyword.</summary>
        [Keyword("hexagon")] Hexagon,

        /// <summary>"hf_gray_16" keyword.</summary>
        [Keyword("hf_gray_16")] HfGray_16,

        /// <summary>"hierarchy" keyword.</summary>
        [Keyword("hierarchy")] Hierarchy,

        /// <summary>"hollow" keyword.</summary>
        [Keyword("hollow")] Hollow,

        /// <summary>"hypercomplex" keyword.</summary>
        [Keyword("hypercomplex")] Hypercomplex,

        /// <summary>"if" keyword.</summary>
        [Keyword("if")] If,

        /// <summary>"ifdef" keyword.</summary>
        [Keyword("ifdef")] Ifdef,

        /// <summary>"iff" keyword.</summary>
        [Keyword("iff")] Iff,

        /// <summary>"ifndef" keyword.</summary>
        [Keyword("ifndef")] Ifndef,

        /// <summary>"image_map" keyword.</summary>
        [Keyword("image_map")] ImageMap,

        /// <summary>"image_pattern" keyword.</summary>
        [Keyword("image_pattern")] ImagePattern,

        /// <summary>"importance" keyword.</summary>
        [Keyword("importance")] Importance,

        /// <summary>"include" keyword.</summary>
        [Keyword("include")] Include,

        /// <summary>"inside" keyword.</summary>
        [Keyword("inside")] Inside,

        /// <summary>"inside_vector" keyword.</summary>
        [Keyword("inside_vector")] InsideVector,

        /// <summary>"int" keyword.</summary>
        [Keyword("int")] Int,

        /// <summary>"interior" keyword.</summary>
        [Keyword("interior")] Interior,

        /// <summary>"interior_texture" keyword.</summary>
        [Keyword("interior_texture")] InteriorTexture,

        /// <summary>"internal" keyword.</summary>
        [Keyword("internal")] Internal,

        /// <summary>"interpolate" keyword.</summary>
        [Keyword("interpolate")] Interpolate,

        /// <summary>"intersection" keyword.</summary>
        [Keyword("intersection")] Intersection,

        /// <summary>"intervals" keyword.</summary>
        [Keyword("intervals")] Intervals,

        /// <summary>"inverse" keyword.</summary>
        [Keyword("inverse")] Inverse,

        /// <summary>"ior" keyword.</summary>
        [Keyword("ior")] Ior,

        /// <summary>"irid" keyword.</summary>
        [Keyword("irid")] Irid,

        /// <summary>"irid_wavelength" keyword.</summary>
        [Keyword("irid_wavelength")] IridWavelength,

        /// <summary>"isosurface" keyword.</summary>
        [Keyword("isosurface")] Isosurface,

        /// <summary>"jitter" keyword.</summary>
        [Keyword("jitter")] Jitter,

        /// <summary>"jpeg" keyword.</summary>
        [Keyword("jpeg")] Jpeg,

        /// <summary>"julia" keyword.</summary>
        [Keyword("julia")] Julia,

        /// <summary>"julia_fractal" keyword.</summary>
        [Keyword("julia_fractal")] JuliaFractal,

        /// <summary>"lambda" keyword.</summary>
        [Keyword("lambda")] Lambda,

        /// <summary>"lathe" keyword.</summary>
        [Keyword("lathe")] Lathe,

        /// <summary>"lemon" keyword.</summary>
        [Keyword("lemon")] Lemon,

        /// <summary>"leopard" keyword.</summary>
        [Keyword("leopard")] Leopard,

        /// <summary>"light_group" keyword.</summary>
        [Keyword("light_group")] LightGroup,

        /// <summary>"light_source" keyword.</summary>
        [Keyword("light_source")] LightSource,

        /// <summary>"linear_spline" keyword.</summary>
        [Keyword("linear_spline")] LinearSpline,

        /// <summary>"linear_sweep" keyword.</summary>
        [Keyword("linear_sweep")] LinearSweep,

        /// <summary>"ln" keyword.</summary>
        [Keyword("ln")] Ln,

        /// <summary>"load_file" keyword.</summary>
        [Keyword("load_file")] LoadFile,

        /// <summary>"local" keyword.</summary>
        [Keyword("local")] Local,

        /// <summary>"location" keyword.</summary>
        [Keyword("location")] Location,

        /// <summary>"log" keyword.</summary>
        [Keyword("log")] Log,

        /// <summary>"look_at" keyword.</summary>
        [Keyword("look_at")] LookAt,

        /// <summary>"looks_like" keyword.</summary>
        [Keyword("looks_like")] LooksLike,

        /// <summary>"low_error_factor" keyword.</summary>
        [Keyword("low_error_factor")] LowErrorFactor,

        /// <summary>"macro" keyword.</summary>
        [Keyword("macro")] Macro,

        /// <summary>"magnet" keyword.</summary>
        [Keyword("magnet")] Magnet,

        /// <summary>"major_radius" keyword.</summary>
        [Keyword("major_radius")] MajorRadius,

        /// <summary>"mandel" keyword.</summary>
        [Keyword("mandel")] Mandel,

        /// <summary>"map_type" keyword.</summary>
        [Keyword("map_type")] MapType,

        /// <summary>"marble" keyword.</summary>
        [Keyword("marble")] Marble,

        /// <summary>"material" keyword.</summary>
        [Keyword("material")] Material,

        /// <summary>"material_map" keyword.</summary>
        [Keyword("material_map")] MaterialMap,

        /// <summary>"matrix" keyword.</summary>
        [Keyword("matrix")] Matrix,

        /// <summary>"max" keyword.</summary>
        [Keyword("max")] Max,

        /// <summary>"max_extent" keyword.</summary>
        [Keyword("max_extent")] MaxExtent,

        /// <summary>"max_gradient" keyword.</summary>
        [Keyword("max_gradient")] MaxGradient,

        /// <summary>"max_intersections" keyword.</summary>
        [Keyword("max_intersections")] MaxIntersections,

        /// <summary>"max_iteration" keyword.</summary>
        [Keyword("max_iteration")] MaxIteration,

        /// <summary>"max_sample" keyword.</summary>
        [Keyword("max_sample")] MaxSample,

        /// <summary>"max_trace" keyword.</summary>
        [Keyword("max_trace")] MaxTrace,

        /// <summary>"max_trace_level" keyword.</summary>
        [Keyword("max_trace_level")] MaxTraceLevel,

        /// <summary>"maximum_reuse" keyword.</summary>
        [Keyword("maximum_reuse")] MaximumReuse,

        /// <summary>"media" keyword.</summary>
        [Keyword("media")] Media,

        /// <summary>"media_attenuation" keyword.</summary>
        [Keyword("media_attenuation")] MediaAttenuation,

        /// <summary>"media_interaction" keyword.</summary>
        [Keyword("media_interaction")] MediaInteraction,

        /// <summary>"merge" keyword.</summary>
        [Keyword("merge")] Merge,

        /// <summary>"mesh" keyword.</summary>
        [Keyword("mesh")] Mesh,

        /// <summary>"mesh_camera" keyword.</summary>
        [Keyword("mesh_camera")] MeshCamera,

        /// <summary>"mesh2" keyword.</summary>
        [Keyword("mesh2")] Mesh2,

        /// <summary>"metallic" keyword.</summary>
        [Keyword("metallic")] Metallic,

        /// <summary>"method" keyword.</summary>
        [Keyword("method")] Method,

        /// <summary>"metric" keyword.</summary>
        [Keyword("metric")] Metric,

        /// <summary>"min" keyword.</summary>
        [Keyword("min")] Min,

        /// <summary>"min_extent" keyword.</summary>
        [Keyword("min_extent")] MinExtent,

        /// <summary>"minimum_reuse" keyword.</summary>
        [Keyword("minimum_reuse")] MinimumReuse,

        /// <summary>"mm_per_unit" keyword.</summary>
        [Keyword("mm_per_unit")] MmPerUnit,

        /// <summary>"mod" keyword.</summary>
        [Keyword("mod")] Mod,

        /// <summary>"mortar" keyword.</summary>
        [Keyword("mortar")] Mortar,

        /// <summary>"natural_spline" keyword.</summary>
        [Keyword("natural_spline")] NaturalSpline,

        /// <summary>"nearest_count" keyword.</summary>
        [Keyword("nearest_count")] NearestCount,

        /// <summary>"no" keyword.</summary>
        [Keyword("no")] No,

        /// <summary>"no_bump_scale" keyword.</summary>
        [Keyword("no_bump_scale")] NoBumpScale,

        /// <summary>"no_image" keyword.</summary>
        [Keyword("no_image")] NoImage,

        /// <summary>"no_radiosity" keyword.</summary>
        [Keyword("no_radiosity")] NoRadiosity,

        /// <summary>"no_reflection" keyword.</summary>
        [Keyword("no_reflection")] NoReflection,

        /// <summary>"no_shadow" keyword.</summary>
        [Keyword("no_shadow")] NoShadow,

        /// <summary>"noise_generator" keyword.</summary>
        [Keyword("noise_generator")] NoiseGenerator,

        /// <summary>"normal" keyword.</summary>
        [Keyword("normal")] Normal,

        /// <summary>"normal_indices" keyword.</summary>
        [Keyword("normal_indices")] NormalIndices,

        /// <summary>"normal_map" keyword.</summary>
        [Keyword("normal_map")] NormalMap,

        /// <summary>"normal_vectors" keyword.</summary>
        [Keyword("normal_vectors")] NormalVectors,

        /// <summary>"now" keyword.</summary>
        [Keyword("now")] Now,

        /// <summary>"number_of_sides" keyword.</summary>
        [Keyword("number_of_sides")] NumberOfSides,

        /// <summary>"number_of_tiles" keyword.</summary>
        [Keyword("number_of_tiles")] NumberOfTiles,

        /// <summary>"number_of_waves" keyword.</summary>
        [Keyword("number_of_waves")] NumberOfWaves,

        /// <summary>"object" keyword.</summary>
        [Keyword("object")] Object,

        /// <summary>"octaves" keyword.</summary>
        [Keyword("octaves")] Octaves,

        /// <summary>"off" keyword.</summary>
        [Keyword("off")] Off,

        /// <summary>"offset" keyword.</summary>
        [Keyword("offset")] Offset,

        /// <summary>"omega" keyword.</summary>
        [Keyword("omega")] Omega,

        /// <summary>"omnimax" keyword.</summary>
        [Keyword("omnimax")] Omnimax,

        /// <summary>"on" keyword.</summary>
        [Keyword("on")] On,

        /// <summary>"once" keyword.</summary>
        [Keyword("once")] Once,

        /// <summary>"onion" keyword.</summary>
        [Keyword("onion")] Onion,

        /// <summary>"open" keyword.</summary>
        [Keyword("open")] Open,

        /// <summary>"optional" keyword.</summary>
        [Keyword("optional")] Optional,

        /// <summary>"orient" keyword.</summary>
        [Keyword("orient")] Orient,

        /// <summary>"orientation" keyword.</summary>
        [Keyword("orientation")] Orientation,

        /// <summary>"orthographic" keyword.</summary>
        [Keyword("orthographic")] Orthographic,

        /// <summary>"ovus" keyword.</summary>
        [Keyword("ovus")] Ovus,

        /// <summary>"panoramic" keyword.</summary>
        [Keyword("panoramic")] Panoramic,

        /// <summary>"parallel" keyword.</summary>
        [Keyword("parallel")] Parallel,

        /// <summary>"parametric" keyword.</summary>
        [Keyword("parametric")] Parametric,

        /// <summary>"pass_through" keyword.</summary>
        [Keyword("pass_through")] PassThrough,

        /// <summary>"pattern" keyword.</summary>
        [Keyword("pattern")] Pattern,

        /// <summary>"pavement" keyword.</summary>
        [Keyword("pavement")] Pavement,

        /// <summary>"perspective" keyword.</summary>
        [Keyword("perspective")] Perspective,

        /// <summary>"pgm" keyword.</summary>
        [Keyword("pgm")] Pgm,

        /// <summary>"phase" keyword.</summary>
        [Keyword("phase")] Phase,

        /// <summary>"phong" keyword.</summary>
        [Keyword("phong")] Phong,

        /// <summary>"phong_size" keyword.</summary>
        [Keyword("phong_size")] PhongSize,

        /// <summary>"photons" keyword.</summary>
        [Keyword("photons")] Photons,

        /// <summary>"pi" keyword.</summary>
        [Keyword("pi")] Pi,

        /// <summary>"pigment" keyword.</summary>
        [Keyword("pigment")] Pigment,

        /// <summary>"pigment_map" keyword.</summary>
        [Keyword("pigment_map")] PigmentMap,

        /// <summary>"pigment_pattern" keyword.</summary>
        [Keyword("pigment_pattern")] PigmentPattern,

        /// <summary>"planar" keyword.</summary>
        [Keyword("planar")] Planar,

        /// <summary>"plane" keyword.</summary>
        [Keyword("plane")] Plane,

        /// <summary>"png" keyword.</summary>
        [Keyword("png")] Png,

        /// <summary>"point_at" keyword.</summary>
        [Keyword("point_at")] PointAt,

        /// <summary>"polarity" keyword.</summary>
        [Keyword("polarity")] Polarity,

        /// <summary>"poly" keyword.</summary>
        [Keyword("poly")] Poly,

        /// <summary>"poly_wave" keyword.</summary>
        [Keyword("poly_wave")] PolyWave,

        /// <summary>"polygon" keyword.</summary>
        [Keyword("polygon")] Polygon,

        /// <summary>"polynomial" keyword.</summary>
        [Keyword("polynomial")] Polynomial,

        /// <summary>"pot" keyword.</summary>
        [Keyword("pot")] Pot,

        /// <summary>"potential" keyword.</summary>
        [Keyword("potential")] Potential,

        /// <summary>"pow" keyword.</summary>
        [Keyword("pow")] Pow,

        /// <summary>"ppm" keyword.</summary>
        [Keyword("ppm")] Ppm,

        /// <summary>"precision" keyword.</summary>
        [Keyword("precision")] Precision,

        /// <summary>"precompute" keyword.</summary>
        [Keyword("precompute")] Precompute,

        /// <summary>"premultiplied" keyword.</summary>
        [Keyword("premultiplied")] Premultiplied,

        /// <summary>"pretrace_end" keyword.</summary>
        [Keyword("pretrace_end")] PretraceEnd,

        /// <summary>"pretrace_start" keyword.</summary>
        [Keyword("pretrace_start")] PretraceStart,

        /// <summary>"prism" keyword.</summary>
        [Keyword("prism")] Prism,

        /// <summary>"prod" keyword.</summary>
        [Keyword("prod")] Prod,

        /// <summary>"projected_through" keyword.</summary>
        [Keyword("projected_through")] ProjectedThrough,

        /// <summary>"pwr" keyword.</summary>
        [Keyword("pwr")] Pwr,

        /// <summary>"quadratic_spline" keyword.</summary>
        [Keyword("quadratic_spline")] QuadraticSpline,

        /// <summary>"quadric" keyword.</summary>
        [Keyword("quadric")] Quadric,

        /// <summary>"quartic" keyword.</summary>
        [Keyword("quartic")] Quartic,

        /// <summary>"quaternion" keyword.</summary>
        [Keyword("quaternion")] Quaternion,

        /// <summary>"quick_color" keyword.</summary>
        [Keyword("quick_color")] QuickColor,

        /// <summary>"quilted" keyword.</summary>
        [Keyword("quilted")] Quilted,

        /// <summary>"radial" keyword.</summary>
        [Keyword("radial")] Radial,

        /// <summary>"radians" keyword.</summary>
        [Keyword("radians")] Radians,

        /// <summary>"radiosity" keyword.</summary>
        [Keyword("radiosity")] Radiosity,

        /// <summary>"radius" keyword.</summary>
        [Keyword("radius")] Radius,

        /// <summary>"rainbow" keyword.</summary>
        [Keyword("rainbow")] Rainbow,

        /// <summary>"ramp_wave" keyword.</summary>
        [Keyword("ramp_wave")] RampWave,

        /// <summary>"rand" keyword.</summary>
        [Keyword("rand")] Rand,

        /// <summary>"range" keyword.</summary>
        [Keyword("range")] Range,

        /// <summary>"ratio" keyword.</summary>
        [Keyword("ratio")] Ratio,

        /// <summary>"read" keyword.</summary>
        [Keyword("read")] Read,

        /// <summary>"reciprocal" keyword.</summary>
        [Keyword("reciprocal")] Reciprocal,

        /// <summary>"recursion_limit" keyword.</summary>
        [Keyword("recursion_limit")] RecursionLimit,

        /// <summary>"red" keyword.</summary>
        [Keyword("red")] Red,

        /// <summary>"reflection" keyword.</summary>
        [Keyword("reflection")] Reflection,

        /// <summary>"reflection_exponent" keyword.</summary>
        [Keyword("reflection_exponent")] ReflectionExponent,

        /// <summary>"refraction" keyword.</summary>
        [Keyword("refraction")] Refraction,

        /// <summary>"render" keyword.</summary>
        [Keyword("render")] Render,

        /// <summary>"repeat" keyword.</summary>
        [Keyword("repeat")] Repeat,

        /// <summary>"rgb" keyword.</summary>
        [Keyword("rgb")] Rgb,

        /// <summary>"rgbf" keyword.</summary>
        [Keyword("rgbf")] Rgbf,

        /// <summary>"rgbft" keyword.</summary>
        [Keyword("rgbft")] Rgbft,

        /// <summary>"rgbt" keyword.</summary>
        [Keyword("rgbt")] Rgbt,

        /// <summary>"right" keyword.</summary>
        [Keyword("right")] Right,

        /// <summary>"ripples" keyword.</summary>
        [Keyword("ripples")] Ripples,

        /// <summary>"rotate" keyword.</summary>
        [Keyword("rotate")] Rotate,

        /// <summary>"roughness" keyword.</summary>
        [Keyword("roughness")] Roughness,

        /// <summary>"samples" keyword.</summary>
        [Keyword("samples")] Samples,

        /// <summary>"save_file" keyword.</summary>
        [Keyword("save_file")] SaveFile,

        /// <summary>"scale" keyword.</summary>
        [Keyword("scale")] Scale,

        /// <summary>"scallop_wave" keyword.</summary>
        [Keyword("scallop_wave")] ScallopWave,

        /// <summary>"scattering" keyword.</summary>
        [Keyword("scattering")] Scattering,

        /// <summary>"seed" keyword.</summary>
        [Keyword("seed")] Seed,

        /// <summary>"select" keyword.</summary>
        [Keyword("select")] Select,

        /// <summary>"shadowless" keyword.</summary>
        [Keyword("shadowless")] Shadowless,

        /// <summary>"sine_wave" keyword.</summary>
        [Keyword("sine_wave")] SineWave,

        /// <summary>"sin" keyword.</summary>
        [Keyword("sin")] Sin,

        /// <summary>"sinh" keyword.</summary>
        [Keyword("sinh")] Sinh,

        /// <summary>"sint16be" keyword.</summary>
        [Keyword("sint16be")] Sint16be,

        /// <summary>"sint16le" keyword.</summary>
        [Keyword("sint16le")] Sint16le,

        /// <summary>"sint32be" keyword.</summary>
        [Keyword("sint32be")] Sint32be,

        /// <summary>"sint32le" keyword.</summary>
        [Keyword("sint32le")] Sint32le,

        /// <summary>"sint8" keyword.</summary>
        [Keyword("sint8")] Sint8,

        /// <summary>"size" keyword.</summary>
        [Keyword("size")] Size,

        /// <summary>"sky" keyword.</summary>
        [Keyword("sky")] Sky,

        /// <summary>"sky_sphere" keyword.</summary>
        [Keyword("sky_sphere")] SkySphere,

        /// <summary>"slice" keyword.</summary>
        [Keyword("slice")] Slice,

        /// <summary>"slope" keyword.</summary>
        [Keyword("slope")] Slope,

        /// <summary>"slope_map" keyword.</summary>
        [Keyword("slope_map")] SlopeMap,

        /// <summary>"smooth" keyword.</summary>
        [Keyword("smooth")] Smooth,

        /// <summary>"smooth_triangle" keyword.</summary>
        [Keyword("smooth_triangle")] SmoothTriangle,

        /// <summary>"solid" keyword.</summary>
        [Keyword("solid")] Solid,

        /// <summary>"sor" keyword.</summary>
        [Keyword("sor")] Sor,

        /// <summary>"spacing" keyword.</summary>
        [Keyword("spacing")] Spacing,

        /// <summary>"specular" keyword.</summary>
        [Keyword("specular")] Specular,

        /// <summary>"sphere" keyword.</summary>
        [Keyword("sphere")] Sphere,

        /// <summary>"sphere_sweep" keyword.</summary>
        [Keyword("sphere_sweep")] SphereSweep,

        /// <summary>"spherical" keyword.</summary>
        [Keyword("spherical")] Spherical,

        /// <summary>"spiral1" keyword.</summary>
        [Keyword("spiral1")] Spiral1,

        /// <summary>"spiral2" keyword.</summary>
        [Keyword("spiral2")] Spiral2,

        /// <summary>"spline" keyword.</summary>
        [Keyword("spline")] Spline,

        /// <summary>"split_union" keyword.</summary>
        [Keyword("split_union")] SplitUnion,

        /// <summary>"spotlight" keyword.</summary>
        [Keyword("spotlight")] Spotlight,

        /// <summary>"spotted" keyword.</summary>
        [Keyword("spotted")] Spotted,

        /// <summary>"sqrt" keyword.</summary>
        [Keyword("sqrt")] Sqrt,

        /// <summary>"sqr" keyword.</summary>
        [Keyword("sqr")] Sqr,

        /// <summary>"square" keyword.</summary>
        [Keyword("square")] Square,

        /// <summary>"srgb" keyword.</summary>
        [Keyword("srgb")] Srgb,

        /// <summary>"srgbf" keyword.</summary>
        [Keyword("srgbf")] Srgbf,

        /// <summary>"srgbft" keyword.</summary>
        [Keyword("srgbft")] Srgbft,

        /// <summary>"srgbt" keyword.</summary>
        [Keyword("srgbt")] Srgbt,

        /// <summary>"statistics" keyword.</summary>
        [Keyword("statistics")] Statistics,

        /// <summary>"str" keyword.</summary>
        [Keyword("str")] Str,

        /// <summary>"strcmp" keyword.</summary>
        [Keyword("strcmp")] Strcmp,

        /// <summary>"strength" keyword.</summary>
        [Keyword("strength")] Strength,

        /// <summary>"strlen" keyword.</summary>
        [Keyword("strlen")] Strlen,

        /// <summary>"strlwr" keyword.</summary>
        [Keyword("strlwr")] Strlwr,

        /// <summary>"strupr" keyword.</summary>
        [Keyword("strupr")] Strupr,

        /// <summary>"sturm" keyword.</summary>
        [Keyword("sturm")] Sturm,

        /// <summary>"substr" keyword.</summary>
        [Keyword("substr")] Substr,

        /// <summary>"subsurface" keyword.</summary>
        [Keyword("subsurface")] Subsurface,

        /// <summary>"sum" keyword.</summary>
        [Keyword("sum")] Sum,

        /// <summary>"superellipsoid" keyword.</summary>
        [Keyword("superellipsoid")] Superellipsoid,

        /// <summary>"switch" keyword.</summary>
        [Keyword("switch")] Switch,

        /// <summary>"sys" keyword.</summary>
        [Keyword("sys")] Sys,

        /// <summary>"t" keyword.</summary>
        [Keyword("t")] T,

        /// <summary>"tan" keyword.</summary>
        [Keyword("tan")] Tan,

        /// <summary>"tanh" keyword.</summary>
        [Keyword("tanh")] Tanh,

        /// <summary>"target" keyword.</summary>
        [Keyword("target")] Target,

        /// <summary>"tau" keyword.</summary>
        [Keyword("tau")] Tau,

        /// <summary>"text" keyword.</summary>
        [Keyword("text")] Text,

        /// <summary>"texture" keyword.</summary>
        [Keyword("texture")] Texture,

        /// <summary>"texture_list" keyword.</summary>
        [Keyword("texture_list")] TextureList,

        /// <summary>"texture_map" keyword.</summary>
        [Keyword("texture_map")] TextureMap,

        /// <summary>"tga" keyword.</summary>
        [Keyword("tga")] Tga,

        /// <summary>"thickness" keyword.</summary>
        [Keyword("thickness")] Thickness,

        /// <summary>"threshold" keyword.</summary>
        [Keyword("threshold")] Threshold,

        /// <summary>"tiff" keyword.</summary>
        [Keyword("tiff")] Tiff,

        /// <summary>"tightness" keyword.</summary>
        [Keyword("tightness")] Tightness,

        /// <summary>"tile2" keyword.</summary>
        [Keyword("tile2")] Tile2,

        /// <summary>"tiles" keyword.</summary>
        [Keyword("tiles")] Tiles,

        /// <summary>"tiling" keyword.</summary>
        [Keyword("tiling")] Tiling,

        /// <summary>"tolerance" keyword.</summary>
        [Keyword("tolerance")] Tolerance,

        /// <summary>"toroidal" keyword.</summary>
        [Keyword("toroidal")] Toroidal,

        /// <summary>"torus" keyword.</summary>
        [Keyword("torus")] Torus,

        /// <summary>"trace" keyword.</summary>
        [Keyword("trace")] Trace,

        /// <summary>"transform" keyword.</summary>
        [Keyword("transform")] Transform,

        /// <summary>"translate" keyword.</summary>
        [Keyword("translate")] Translate,

        /// <summary>"translucency" keyword.</summary>
        [Keyword("translucency")] Translucency,

        /// <summary>"transmit" keyword.</summary>
        [Keyword("transmit")] Transmit,

        /// <summary>"triangle" keyword.</summary>
        [Keyword("triangle")] Triangle,

        /// <summary>"triangle_wave" keyword.</summary>
        [Keyword("triangle_wave")] TriangleWave,

        /// <summary>"triangular" keyword.</summary>
        [Keyword("triangular")] Triangular,

        /// <summary>"true" keyword.</summary>
        [Keyword("true")] True,

        /// <summary>"ttf" keyword.</summary>
        [Keyword("ttf")] Ttf,

        /// <summary>"turb_depth" keyword.</summary>
        [Keyword("turb_depth")] TurbDepth,

        /// <summary>"turbulence" keyword.</summary>
        [Keyword("turbulence")] Turbulence,

        /// <summary>"type" keyword.</summary>
        [Keyword("type")] Type,

        /// <summary>"u" keyword.</summary>
        [Keyword("u")] U,

        /// <summary>"u_steps" keyword.</summary>
        [Keyword("u_steps")] USteps,

        /// <summary>"uint16be" keyword.</summary>
        [Keyword("uint16be")] Uint16be,

        /// <summary>"uint16le" keyword.</summary>
        [Keyword("uint16le")] Uint16le,

        /// <summary>"uint8" keyword.</summary>
        [Keyword("uint8")] Uint8,

        /// <summary>"ultra_wide_angle" keyword.</summary>
        [Keyword("ultra_wide_angle")] UltraWideAngle,

        /// <summary>"undef" keyword.</summary>
        [Keyword("undef")] Undef,

        /// <summary>"union" keyword.</summary>
        [Keyword("union")] Union,

        /// <summary>"unofficial" keyword.</summary>
        [Keyword("unofficial")] Unofficial,

        /// <summary>"up" keyword.</summary>
        [Keyword("up")] Up,

        /// <summary>"use_alpha" keyword.</summary>
        [Keyword("use_alpha")] UseAlpha,

        /// <summary>"use_color" keyword.</summary>
        [Keyword("use_color")] UseColor,

        /// <summary>"use_index" keyword.</summary>
        [Keyword("use_index")] UseIndex,

        /// <summary>"user_defined" keyword.</summary>
        [Keyword("user_defined")] UserDefined,

        /// <summary>"utf8" keyword.</summary>
        [Keyword("utf8")] Utf8,

        /// <summary>"uv_indices" keyword.</summary>
        [Keyword("uv_indices")] UvIndices,

        /// <summary>"uv_mapping" keyword.</summary>
        [Keyword("uv_mapping")] UvMapping,

        /// <summary>"uv_vectors" keyword.</summary>
        [Keyword("uv_vectors")] UvVectors,

        /// <summary>"v" keyword.</summary>
        [Keyword("v")] V,

        /// <summary>"v_steps" keyword.</summary>
        [Keyword("v_steps")] VSteps,

        /// <summary>"val" keyword.</summary>
        [Keyword("val")] Val,

        /// <summary>"variance" keyword.</summary>
        [Keyword("variance")] Variance,

        /// <summary>"vaxis_rotate" keyword.</summary>
        [Keyword("vaxis_rotate")] VaxisRotate,

        /// <summary>"vcross" keyword.</summary>
        [Keyword("vcross")] Vcross,

        /// <summary>"vdot" keyword.</summary>
        [Keyword("vdot")] Vdot,

        /// <summary>"version" keyword.</summary>
        [Keyword("version")] Version,

        /// <summary>"vertex_vectors" keyword.</summary>
        [Keyword("vertex_vectors")] VertexVectors,

        /// <summary>"vlength" keyword.</summary>
        [Keyword("vlength")] Vlength,

        /// <summary>"vnormalize" keyword.</summary>
        [Keyword("vnormalize")] Vnormalize,

        /// <summary>"vrotate" keyword.</summary>
        [Keyword("vrotate")] Vrotate,

        /// <summary>"vstr" keyword.</summary>
        [Keyword("vstr")] Vstr,

        /// <summary>"vturbulence" keyword.</summary>
        [Keyword("vturbulence")] Vturbulence,

        /// <summary>"warning" keyword.</summary>
        [Keyword("warning")] Warning,

        /// <summary>"warp" keyword.</summary>
        [Keyword("warp")] Warp,

        /// <summary>"water_level" keyword.</summary>
        [Keyword("water_level")] WaterLevel,

        /// <summary>"waves" keyword.</summary>
        [Keyword("waves")] Waves,

        /// <summary>"while" keyword.</summary>
        [Keyword("while")] While,

        /// <summary>"width" keyword.</summary>
        [Keyword("width")] Width,

        /// <summary>"wood" keyword.</summary>
        [Keyword("wood")] Wood,

        /// <summary>"wrinkles" keyword.</summary>
        [Keyword("wrinkles")] Wrinkles,

        /// <summary>"write" keyword.</summary>
        [Keyword("write")] Write,

        /// <summary>"x" keyword.</summary>
        [Keyword("x")] X,

        /// <summary>"xyz" keyword.</summary>
        [Keyword("xyz")] Xyz,

        /// <summary>"y" keyword.</summary>
        [Keyword("y")] Y,

        /// <summary>"yes" keyword.</summary>
        [Keyword("yes")] Yes,

        /// <summary>"z" keyword.</summary>
        [Keyword("z")] Z,
    }

    /// <summary>
    /// Provide a value of the Keyword enumeration with the textual value.
    /// </summary>
    public class KeywordAttribute : Attribute
    {
        private string Name { get; }

        public Keyword Keyword { get; }

        private static readonly Dictionary<Keyword, string> Names = new Dictionary<Keyword, string>();

        public KeywordAttribute(string name)
        {
            this.Name = name;
            Keyword keyword;
            if (Enum.TryParse(name, true, out keyword))
            {
                this.Keyword = keyword;
            }
        }

        public KeywordAttribute(Keyword keyword)
        {
            this.Keyword = keyword;
        }

        public static string ToString(Keyword keyword)
        {
            string name;
            lock (Names)
            {
                if (!Names.TryGetValue(keyword, out name))
                {
                    FieldInfo field = typeof(Keyword).GetField(keyword.ToString());
                    KeywordAttribute attr = field.GetCustomAttributeFast<KeywordAttribute>();
                    name = attr.ToString();
                    Names.Add(keyword, name);
                }
            }

            return name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}