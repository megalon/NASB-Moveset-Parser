using MovesetParser.StateActions;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using static MovesetParser.StateActions.StateAction;

namespace JsonConverter.Converters
{
    public class StateActionConverter : JsonConverter<StateAction>
    {
        private static readonly FieldInfo tidInfo = typeof(StateAction).GetField(nameof(StateAction.TID));

        public override StateAction ReadJson(JsonReader reader, Type objectType, [AllowNull] StateAction existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return Converter.ReadJson<TypeId, StateAction>(reader, serializer, tidInfo, res => res switch
            {
                TypeId.SADebugMessage => new SADebugMessage(),
                TypeId.SAPlayAnim => new SAPlayAnim(),
                TypeId.SAPlayRootAnim => new SAPlayRootAnim(),
                TypeId.SASnapAnimWeights => new SASnapAnimWeights(),
                TypeId.SAStandardInput => new SAStandardInput(),
                TypeId.SAInputAction => new SAInputAction(),
                TypeId.SADeactivateInputAction => new SADeactivateInputAction(),
                TypeId.SAAddInputEventFromFrame => new SAAddInputEventFromFrame(),
                TypeId.SACancelToState => new SACancelToState(),
                TypeId.SACustomCall => new SACustomCall(),
                TypeId.SATimedAction => new SATimedAction(),
                TypeId.SAOrderSensitive => new SAOrderSensitive(),
                TypeId.SAProxyMove => new SAProxyMove(),
                TypeId.SACheckThing => new SACheckThing(),
                TypeId.SAActiveAction => new SAActiveAction(),
                TypeId.SADeactivateAction => new SADeactivateAction(),
                TypeId.SASetFloatTarget => new SASetFloatTarget(),
                TypeId.SAOnBounce => new SAOnBounce(),
                TypeId.SAOnLeaveEdge => new SAOnLeaveEdge(),
                TypeId.SAOnStoppedAtEdge => new SAOnStoppedAtEdge(),
                TypeId.SAOnLand => new SAOnLand(),
                TypeId.SAOnCancel => new SAOnCancel(),
                TypeId.SARefreshAttack => new SARefreshAttack(),
                TypeId.SAEndAttack => new SAEndAttack(),
                TypeId.SASetHitboxCount => new SASetHitboxCount(),
                TypeId.SAConfigHitbox => new SAConfigHitbox(),
                TypeId.SASetAtkProp => new SASetAtkProp(),
                TypeId.SAManipHitBox => new SAManipHitBox(),
                TypeId.SAUpdateHurtboxes => new SAUpdateHurtboxes(),
                TypeId.SASetupHurtboxes => new SASetupHurtboxes(),
                TypeId.SAManipHurtBox => new SAManipHurtBox(),
                TypeId.SABoneState => new SABoneState(),
                TypeId.SABoneScale => new SABoneScale(),
                TypeId.SASpawnAgent => new SASpawnAgent(),
                TypeId.SALocalFX => new SALocalFX(),
                TypeId.SASpawnFX => new SASpawnFX(),
                TypeId.SASetHitboxFX => new SASetHitboxFX(),
                TypeId.SAPlaySFX => new SAPlaySFX(),
                TypeId.SASetHitboxSFX => new SASetHitboxSFX(),
                TypeId.SAColorTint => new SAColorTint(),
                TypeId.SAFindFloor => new SAFindFloor(),
                TypeId.SAHurtGrabbed => new SAHurtGrabbed(),
                TypeId.SALaunchGrabbed => new SALaunchGrabbed(),
                TypeId.SAStateCancelGrabbed => new SAStateCancelGrabbed(),
                TypeId.SAEndGrab => new SAEndGrab(),
                TypeId.SAGrabNotifyEscape => new SAGrabNotifyEscape(),
                TypeId.SAIgnoreGrabbed => new SAIgnoreGrabbed(),
                TypeId.SAEventKO => new SAEventKO(),
                TypeId.SAEventKOGrabbed => new SAEventKOGrabbed(),
                TypeId.SACameraShake => new SACameraShake(),
                TypeId.SAResetOnHits => new SAResetOnHits(),
                TypeId.SAOnHit => new SAOnHit(),
                TypeId.SAFastForwardState => new SAFastForwardState(),
                TypeId.SATimingTweak => new SATimingTweak(),
                TypeId.SAMapAnimation => new SAMapAnimation(),
                TypeId.SAMapAnimationSimple => new SAMapAnimationSimple(),
                TypeId.SAAlterMoveDT => new SAAlterMoveDT(),
                TypeId.SAAlterMoveVel => new SAAlterMoveVel(),
                TypeId.SASetStagePart => new SASetStagePart(),
                TypeId.SASetStagePartsDefault => new SASetStagePartsDefault(),
                TypeId.SAJump => new SAJump(),
                TypeId.SAStopJump => new SAStopJump(),
                TypeId.SAManageAirJump => new SAManageAirJump(),
                TypeId.SALeaveGround => new SALeaveGround(),
                TypeId.SAUnHogEdge => new SAUnHogEdge(),
                TypeId.SAPlaySFXTimeline => new SAPlaySFXTimeline(),
                TypeId.SAFindLastHorizontalInput => new SAFindLastHorizontalInput(),
                TypeId.SASetCommandGrab => new SASetCommandGrab(),
                TypeId.SACameraPunch => new SACameraPunch(),
                TypeId.SASpawnAgent2 => new SASpawnAgent2(),
                TypeId.SAManipDecorChain => new SAManipDecorChain(),
                TypeId.SAUpdateHitboxes => new SAUpdateHitboxes(),
                TypeId.SASampleAnim => new SASampleAnim(),
                TypeId.SAForceExtraInputCheck => new SAForceExtraInputCheck(),
                TypeId.SALaunchGrabbedCustom => new SALaunchGrabbedCustom(),
                TypeId.SAPlayCategoryVoiceLine => new SAPlayCategoryVoiceLine(),
                TypeId.SAStopVoiceLines => new SAStopVoiceLines(),
                TypeId.SAOnLeaveParent => new SAOnLeaveParent(),
                TypeId.StateAction => new StateAction(),
                _ => throw new JsonException(),
            });
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] StateAction value, JsonSerializer serializer)
        {
            Converter.WriteJson(writer, value, serializer, tidInfo);
        }
    }
}
