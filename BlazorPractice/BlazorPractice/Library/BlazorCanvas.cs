using Microsoft.JSInterop;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;

namespace BlazorPractice.Library
{
    public class BlazorCanvas
    {
        private IJSObjectReference Reference { get; set; }

        public static async Task<BlazorCanvas> Get(IJSRuntime runtime, string canvasID)
        {
            var a = await runtime.GetValueAsync<IJSObjectReference>("document");
            var b = await a.InvokeAsync<IJSObjectReference>("getElementById", canvasID);

            var canvasContext2D = new BlazorCanvas(b);
            return canvasContext2D;
        }

        private BlazorCanvas(IJSObjectReference canvasContextReference)
        {
            Reference = canvasContextReference;
        }

        public async Task<decimal> GetOffsetWidth()
        {
            return await Reference.GetValueAsync<decimal>("offsetWidth");
        }

        public async Task SetWidth(decimal value)
        {
            await Reference.SetValueAsync<decimal>("width", value);
        }

        public async Task<decimal> GetOffsetHeight()
        {
            return await Reference.GetValueAsync<decimal>("offsetHeight");
        }

        public async Task SetHeight(decimal value)
        {
            await Reference.SetValueAsync<decimal>("height", value);
        }


        public async Task<IJSObjectReference> GetContext(string contextType)
        {
            return await Reference.InvokeAsync<IJSObjectReference>("getContext", contextType);
        }
    }

    public class BlazorCanvasContext2D
    {
        public static async Task<BlazorCanvasContext2D> Get(IJSRuntime runtime, string canvasID, string contextType)
        {
            var b = await BlazorCanvas.Get(runtime, canvasID);
            var c = await b.GetContext(contextType);

            var canvasContext2D = new BlazorCanvasContext2D(b, c);
            return canvasContext2D;
        }

        private BlazorCanvasContext2D(BlazorCanvas canvas, IJSObjectReference canvasContextReference)
        {
            Canvas = canvas;
            Reference = canvasContextReference;
        }

        private IJSObjectReference Reference { get; set; }

        public BlazorCanvas Canvas { get; init; }
        public string lang { get; set; }
        public string font { get; set; }
        public string textAlign { get; set; }
        public string textBaseline { get; set; }
        public string direction { get; set; }
        public string fontKerning { get; set; }
        public string fontStretch { get; set; }
        public string fontVariantCaps { get; set; }
        public string letterSpacing { get; set; }
        public string textRendering { get; set; }
        public string wordSpacing { get; set; }
        public string globalCompositeOperation { get; set; }
        public string filter { get; set; }
        public string imageSmoothingQuality { get; set; }
        public string strokeStyle { get; set; }

        public async Task<string> GetFillStyle() => await Reference.GetValueAsync<string>("fillStyle");

        public async Task SetFillStyle(string value) => await Reference.SetValueAsync("fillStyle", value);

        public string shadowColor { get; set; }
        public string lineCap { get; set; }
        public string lineJoin { get; set; }
        public decimal globalAlpha { get; set; }
        public bool imageSmoothingEnabled { get; set; }
        public decimal shadowOffsetX { get; set; }
        public decimal shadowOffsetY { get; set; }
        public decimal shadowBlur { get; set; }
        public decimal lineWidth { get; set; }
        public decimal miterLimit { get; set; }
        public decimal lineDashOffset { get; set; }
        public async Task Clip() => await Reference.InvokeVoidAsync("clip");
        public async Task Clip(Path2D path) => await Reference.InvokeVoidAsync("clip", path);
        public async Task Clip(string fillRule) => await Reference.InvokeVoidAsync("clip", fillRule);
        public async Task Clip(Path2D path, string fillRule) => await Reference.InvokeVoidAsync("clip", path, fillRule);
        public async Task<CanvasGradient> CreateConicGradient(decimal startAngle, decimal x, decimal y) => await CanvasGradient.Create(async () => await Reference.InvokeAsync<IJSObjectReference>("createConicGradient", startAngle, x, y));
        public async Task<ImageData> CreateImageData(decimal x, decimal y) => await ImageData.Create(async () => await Reference.InvokeAsync<IJSObjectReference>("createImageData", x, y));
        public async Task<ImageData> CreateImageData(decimal x, decimal y, string colorSpace = null, string pixelFormat = null) => await ImageData.Create(async () => await Reference.InvokeAsync<IJSObjectReference>("createImageData", x, y, new { colorSpace, pixelFormat }));
        public async Task<ImageData> CreateImageData(ImageData imageData) => await ImageData.Create(async () => await Reference.InvokeAsync<IJSObjectReference>("createImageData", imageData.Reference));
        public async Task createLinearGradient() { }
        public async Task createPattern() { }
        public async Task createRadialGradient() { }
        public async Task drawFocusIfNeeded() { }
        public async Task drawImage() { }
        public async Task fill() { }
        public async Task fillText() { }
        public async Task getContextAttributes() { }
        public async Task<ImageData> getImageData(int sx, int sy, int sw, int sh) => await ImageData.Create(async () => await Reference.InvokeAsync<IJSObjectReference>("getImageData", sx, sy, sw, sh));
        public async Task getLineDash() { }
        public async Task getTransform() { }
        public async Task isContextLost() { }
        public async Task isPointInPath() { }
        public async Task isPointInStroke() { }
        public async Task measureText() { }
        public async Task reset() { }
        public async Task roundRect() { }
        public async Task setLineDash() { }
        public async Task strokeText() { }
        public async Task arc() { }
        public async Task arcTo() { }
        public async Task beginPath() { }
        public async Task bezierCurveTo() { }
        public async Task clearRect() { }
        public async Task closePath() { }
        public async Task ellipse() { }
        public async Task FillRect(int x, int y, int width, int height) => await Reference.InvokeVoidAsync("fillRect", x, y, width, height);

        public async Task LineTo(int x, int y) => await Reference.InvokeVoidAsync("lineTo", x, y);

        public async Task MoveTo(int x, int y) => await Reference.InvokeVoidAsync("moveTo", x, y);
        public async Task putImageData() { }
        public async Task quadraticCurveTo() { }
        public async Task rect() { }
        public async Task resetTransform() { }
        public async Task restore() { }
        public async Task rotate() { }
        public async Task save() { }
        public async Task scale() { }
        public async Task setTransform() { }

        ///<summary> Draw the path you have defined with all those moveTo() and lineTo() methods. </summary>
        public async Task Stroke() => await Reference.InvokeVoidAsync("stroke");
        public async Task strokeRect() { }
        public async Task transform() { }
        public async Task translate() { }
    }

    public class CanvasGradient
    {
        public static async Task<CanvasGradient> Create(Func<Task<IJSObjectReference>> getReferenceFunction)
        {
            return new CanvasGradient { Reference = await getReferenceFunction() };
        }

        private IJSObjectReference? Reference { get; set; }

        private CanvasGradient()
        {

        }
    }

    public class Path2D
    {

    }

    public class ImageData
    {
        public static async Task<ImageData> Create(Func<Task<IJSObjectReference>> getReferenceFunction)
        {
            return new ImageData { Reference = await getReferenceFunction() };
        }

        public IJSObjectReference? Reference { get; private set; }

        private ImageData()
        {

        }

        public async Task<uint[]> GetData() => await Reference.GetValueAsync<uint[]>("data");

        public async Task<byte[]> GetData2(IJSRuntime runtime)
        {
            var data = await Reference.GetValueAsync<IJSObjectReference>("data");
            var buffer = await data.GetValueAsync<IJSObjectReference>("buffer");
            var uint8Array = await runtime.InvokeConstructorAsync("Uint8Array", buffer);
            return await runtime.InvokeAsync<byte[]>("ReturnSelf", uint8Array);
        }

        public async Task<string> GetColorSpace() => await Reference.GetValueAsync<string>("colorSpace");

        public async Task<int> GetHeight() => await Reference.GetValueAsync<int>("height");

        public async Task<int> GetWidth() => await Reference.GetValueAsync<int>("width");

        public async Task<string> GetPixelFormat() => await Reference.GetValueAsync<string>("pixelFormat");
    }
}
