namespace Sandbox.Tools
{
	[Library( "tool_areo", Title = "Aero", Description = "Creates aerodynamic surfaces", Group = "construction" )]
	public partial class Aero : BaseTool
	{

		public override void Activate()
		{
			base.Activate();

		}

		protected override bool IsPreviewTraceValid( TraceResult tr )
		{
			if ( !base.IsPreviewTraceValid( tr ) )
				return false;

			return true;
		}

		public override void CreatePreviews()
		{

		}

		public override void Simulate()
		{
			if ( !Host.IsServer )
				return;

			using ( Prediction.Off() )
			{
				if(Input.Pressed(InputButton.Attack1))
				{
					Vector3 startPos = Owner.EyePos;
					Vector3 dir = Owner.EyeRot.Forward;
					TraceResult tr = Trace.Ray( startPos, startPos + dir * MaxTraceDistance )
					.Ignore( Owner )
					.Run();
					DebugOverlay.Line( tr.StartPos, tr.EndPos, 10.0f, false );
					DebugOverlay.Line( tr.EndPos, tr.EndPos + tr.Normal * 64, 10.0f, false );

				}
			}
		}
	}
}
