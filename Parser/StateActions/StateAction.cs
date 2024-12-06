using MovesetParser.BulkSerialize;

namespace MovesetParser.StateActions
{
    [Serializable]
    public class StateAction : IBulkSerializer
    {
        public TypeId TID = 0;

        public StateAction() { }
        public StateAction(Reader r)
        {
            r.GetNextInt();
            r.GetNextInt();
        }

        public virtual void WriteSerial(Writer writer)
        {
            writer.AddInt(0);
            writer.AddInt(0);
        }

        public static StateAction ReadSerial(Reader reader)
        {
            TypeId typeId = (TypeId)reader.PeekNextInt();
            switch (typeId)
            {
                case TypeId.StateAction:
                    return new StateAction(reader);
                case TypeId.SADebugMessage:
                    return SADebugMessage.ReadSerial(reader);
                case TypeId.SAPlayAnim:
                    return SAPlayAnim.ReadSerial(reader);
                case TypeId.SAPlayRootAnim:
                    return SAPlayRootAnim.ReadSerial(reader);
                case TypeId.SASnapAnimWeights:
                    return SASnapAnimWeights.ReadSerial(reader);
                case TypeId.SAStandardInput:
                    return SAStandardInput.ReadSerial(reader);
                case TypeId.SAInputAction:
                    return SAInputAction.ReadSerial(reader);
                case TypeId.SADeactivateInputAction:
                    return SADeactivateInputAction.ReadSerial(reader);
                case TypeId.SAAddInputEventFromFrame:
                    return SAAddInputEventFromFrame.ReadSerial(reader);
                case TypeId.SACancelToState:
                    return SACancelToState.ReadSerial(reader);
                case TypeId.SACustomCall:
                    return SACustomCall.ReadSerial(reader);
                case TypeId.SATimedAction:
                    return SATimedAction.ReadSerial(reader);
                case TypeId.SAOrderSensitive:
                    return SAOrderSensitive.ReadSerial(reader);
                case TypeId.SAProxyMove:
                    return SAProxyMove.ReadSerial(reader);
                case TypeId.SACheckThing:
                    return SACheckThing.ReadSerial(reader);
                case TypeId.SAActiveAction:
                    return SAActiveAction.ReadSerial(reader);
                case TypeId.SADeactivateAction:
                    return SADeactivateAction.ReadSerial(reader);
                case TypeId.SASetFloatTarget:
                    return SASetFloatTarget.ReadSerial(reader);
                case TypeId.SAOnBounce:
                    return SAOnBounce.ReadSerial(reader);
                case TypeId.SAOnLeaveEdge:
                    return SAOnLeaveEdge.ReadSerial(reader);
                case TypeId.SAOnStoppedAtEdge:
                    return SAOnStoppedAtEdge.ReadSerial(reader);
                case TypeId.SAOnLand:
                    return SAOnLand.ReadSerial(reader);
                case TypeId.SAOnCancel:
                    return SAOnCancel.ReadSerial(reader);
                case TypeId.SARefreshAttack:
                    return SARefreshAttack.ReadSerial(reader);
                case TypeId.SAEndAttack:
                    return SAEndAttack.ReadSerial(reader);
                case TypeId.SASetHitboxCount:
                    return SASetHitboxCount.ReadSerial(reader);
                case TypeId.SAConfigHitbox:
                    return SAConfigHitbox.ReadSerial(reader);
                case TypeId.SASetAtkProp:
                    return SASetAtkProp.ReadSerial(reader);
                case TypeId.SAManipHitBox:
                    return SAManipHitBox.ReadSerial(reader);
                case TypeId.SAUpdateHurtboxes:
                    return SAUpdateHurtboxes.ReadSerial(reader);
                case TypeId.SASetupHurtboxes:
                    return SASetupHurtboxes.ReadSerial(reader);
                case TypeId.SAManipHurtBox:
                    return SAManipHurtBox.ReadSerial(reader);
                case TypeId.SABoneState:
                    return SABoneState.ReadSerial(reader);
                case TypeId.SABoneScale:
                    return SABoneScale.ReadSerial(reader);
                case TypeId.SASpawnAgent:
                    return SASpawnAgent.ReadSerial(reader);
                case TypeId.SALocalFX:
                    return SALocalFX.ReadSerial(reader);
                case TypeId.SASpawnFX:
                    return SASpawnFX.ReadSerial(reader);
                case TypeId.SASetHitboxFX:
                    return SASetHitboxFX.ReadSerial(reader);
                case TypeId.SAPlaySFX:
                    return SAPlaySFX.ReadSerial(reader);
                case TypeId.SASetHitboxSFX:
                    return SASetHitboxSFX.ReadSerial(reader);
                case TypeId.SAColorTint:
                    return SAColorTint.ReadSerial(reader);
                case TypeId.SAFindFloor:
                    return SAFindFloor.ReadSerial(reader);
                case TypeId.SAHurtGrabbed:
                    return SAHurtGrabbed.ReadSerial(reader);
                case TypeId.SALaunchGrabbed:
                    return SALaunchGrabbed.ReadSerial(reader);
                case TypeId.SAStateCancelGrabbed:
                    return SAStateCancelGrabbed.ReadSerial(reader);
                case TypeId.SAEndGrab:
                    return SAEndGrab.ReadSerial(reader);
                case TypeId.SAGrabNotifyEscape:
                    return SAGrabNotifyEscape.ReadSerial(reader);
                case TypeId.SAIgnoreGrabbed:
                    return SAIgnoreGrabbed.ReadSerial(reader);
                case TypeId.SAEventKO:
                    return SAEventKO.ReadSerial(reader);
                case TypeId.SAEventKOGrabbed:
                    return SAEventKOGrabbed.ReadSerial(reader);
                case TypeId.SACameraShake:
                    return SACameraShake.ReadSerial(reader);
                case TypeId.SAResetOnHits:
                    return SAResetOnHits.ReadSerial(reader);
                case TypeId.SAOnHit:
                    return SAOnHit.ReadSerial(reader);
                case TypeId.SAFastForwardState:
                    return SAFastForwardState.ReadSerial(reader);
                case TypeId.SATimingTweak:
                    return SATimingTweak.ReadSerial(reader);
                case TypeId.SAMapAnimation:
                    return SAMapAnimation.ReadSerial(reader);
                case TypeId.SAAlterMoveDT:
                    return SAAlterMoveDT.ReadSerial(reader);
                case TypeId.SAAlterMoveVel:
                    return SAAlterMoveVel.ReadSerial(reader);
                case TypeId.SASetStagePart:
                    return SASetStagePart.ReadSerial(reader);
                case TypeId.SASetStagePartsDefault:
                    return SASetStagePartsDefault.ReadSerial(reader);
                case TypeId.SAJump:
                    return SAJump.ReadSerial(reader);
                case TypeId.SAStopJump:
                    return SAStopJump.ReadSerial(reader);
                case TypeId.SAManageAirJump:
                    return SAManageAirJump.ReadSerial(reader);
                case TypeId.SALeaveGround:
                    return SALeaveGround.ReadSerial(reader);
                case TypeId.SAUnHogEdge:
                    return SAUnHogEdge.ReadSerial(reader);
                case TypeId.SAPlaySFXTimeline:
                    return SAPlaySFXTimeline.ReadSerial(reader);
                case TypeId.SAFindLastHorizontalInput:
                    return SAFindLastHorizontalInput.ReadSerial(reader);
                case TypeId.SASetCommandGrab:
                    return SASetCommandGrab.ReadSerial(reader);
                case TypeId.SACameraPunch:
                    return SACameraPunch.ReadSerial(reader);
                case TypeId.SASpawnAgent2:
                    return SASpawnAgent2.ReadSerial(reader);
                case TypeId.SAManipDecorChain:
                    return SAManipDecorChain.ReadSerial(reader);
                case TypeId.SAUpdateHitboxes:
                    return SAUpdateHitboxes.ReadSerial(reader);
                case TypeId.SASampleAnim:
                    return SASampleAnim.ReadSerial(reader);
                case TypeId.SAForceExtraInputCheck:
                    return SAForceExtraInputCheck.ReadSerial(reader);
                case TypeId.SALaunchGrabbedCustom:
                    return SALaunchGrabbedCustom.ReadSerial(reader);
                case TypeId.SAMapAnimationSimple:
                    return SAMapAnimationSimple.ReadSerial(reader);
                case TypeId.SAPersistLocalFX:
                    return SAPersistLocalFX.ReadSerial(reader);
                case TypeId.SAPlayVoiceLine:
                    return SAPlayVoiceLine.ReadSerial(reader);
                case TypeId.SAPlayCategoryVoiceLine:
                    return SAPlayCategoryVoiceLine.ReadSerial(reader);
                case TypeId.SAStopVoiceLines:
                    return SAStopVoiceLines.ReadSerial(reader);
                case TypeId.SAOnLeaveParent:
                    return SAOnLeaveParent.ReadSerial(reader);
                default:
                    throw new ReadException(reader, $"Unimplemented StateAction serialization for id: {typeId}");
            }
        }

        public enum TypeId
        {
            StateAction = 0,
            SADebugMessage = 1,
            SAPlayAnim = 2,
            SAPlayRootAnim = 3,
            SASnapAnimWeights = 4,
            SAStandardInput = 5,
            SAInputAction = 6,
            SADeactivateInputAction = 7,
            SAAddInputEventFromFrame = 8,
            SACancelToState = 9,
            SACustomCall = 10,
            SATimedAction = 11,
            SAOrderSensitive = 12,
            SAProxyMove = 13,
            SACheckThing = 14,
            SAActiveAction = 15,
            SADeactivateAction = 16,
            SASetFloatTarget = 17,
            SAOnBounce = 18,
            SAOnLeaveEdge = 19,
            SAOnStoppedAtEdge = 20,
            SAOnLand = 21,
            SAOnCancel = 22,
            SARefreshAttack = 23,
            SAEndAttack = 24,
            SASetHitboxCount = 25,
            SAConfigHitbox = 26,
            SASetAtkProp = 27,
            SAManipHitBox = 28,
            SAUpdateHurtboxes = 29,
            SASetupHurtboxes = 30,
            SAManipHurtBox = 31,
            SABoneState = 32,
            SABoneScale = 33,
            SASpawnAgent = 34,
            SALocalFX = 35,
            SASpawnFX = 36,
            SASetHitboxFX = 37,
            SAPlaySFX = 38,
            SASetHitboxSFX = 39,
            SAColorTint = 40,
            SAFindFloor = 41,
            SAHurtGrabbed = 42,
            SALaunchGrabbed = 43,
            SAStateCancelGrabbed = 44,
            SAEndGrab = 45,
            SAGrabNotifyEscape = 46,
            SAIgnoreGrabbed = 47,
            SAEventKO = 48,
            SAEventKOGrabbed = 49,
            SACameraShake = 50,
            SAResetOnHits = 51,
            SAOnHit = 52,
            SAFastForwardState = 53,
            SATimingTweak = 54,
            SAMapAnimation = 55,
            SAAlterMoveDT = 56,
            SAAlterMoveVel = 57,
            SASetStagePart = 58,
            SASetStagePartsDefault = 59,
            SAJump = 60,
            SAStopJump = 61,
            SAManageAirJump = 62,
            SALeaveGround = 63,
            SAUnHogEdge = 64,
            SAPlaySFXTimeline = 65,
            SAFindLastHorizontalInput = 66,
            SASetCommandGrab = 67,
            SACameraPunch = 68,
            SASpawnAgent2 = 69,
            SAManipDecorChain = 70,
            SAUpdateHitboxes = 71,
            SASampleAnim = 72,
            SAForceExtraInputCheck = 73,
            SALaunchGrabbedCustom = 74,
            SAMapAnimationSimple = 75,
            SAPersistLocalFX = 76,
            SAOnLeaveParent = 77,
            SAPlayVoiceLine = 100,
            SAPlayCategoryVoiceLine = 101,
            SAStopVoiceLines = 102
        }
    }
}
