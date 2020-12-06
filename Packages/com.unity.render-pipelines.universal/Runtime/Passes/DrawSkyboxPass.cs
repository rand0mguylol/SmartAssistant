namespace UnityEngine.Rendering.Universal
{
  /// <summary>
  /// Draw the skybox into the given color buffer using the given depth buffer for depth testing.
  ///
  /// This pass renders the standard Unity skybox.
  /// </summary>
  public class DrawSkyboxPass : ScriptableRenderPass
  {

    public DrawSkyboxPass(RenderPassEvent evt)
    {
      renderPassEvent = evt;
    }

    /// <inheritdoc/>
    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
      UniversalRenderPipelineAsset asset = UniversalRenderPipeline.asset;
      if (asset.drawSkybox) context.DrawSkybox(renderingData.cameraData.camera);
    }
  }
}
