using UnityEngine;

namespace TensorFlowLite
{
    /// <summary>
    /// MagicTouch model from MediaPipe's interactive segmentation task
    /// https://developers.google.com/mediapipe/solutions/vision/interactive_segmenter
    /// 
    /// Licensed under Apache License 2.0
    /// See model card for details
    /// https://storage.googleapis.com/mediapipe-assets/Model%20Card%20MagicTouch.pdf
    /// </summary>
    public sealed class MagicTouch : BaseVisionTask
    {
        [System.Serializable]
        public class Options
        {
            public AspectMode aspectMode = AspectMode.Fit;
            public TfLiteDelegateType delegateType = TfLiteDelegateType.GPU;
            public ComputeShader compute = null;
        }

        public MagicTouch(string modelFile, Options options)
        {
            var interpreterOptions = new InterpreterOptions();
            interpreterOptions.AutoAddDelegate(options.delegateType, typeof(float));

            Load(FileUtil.LoadFile(modelFile), interpreterOptions);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        protected override void PostProcess()
        {
        }
    }
}
