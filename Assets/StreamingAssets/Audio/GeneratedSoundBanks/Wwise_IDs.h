/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID BOARD_SELECT = 4175590442U;
        static const AkUniqueID CLOCK_SPEED_1 = 1985760409U;
        static const AkUniqueID CLOCK_SPEED_2 = 1985760410U;
        static const AkUniqueID CLOCK_SPEED_3 = 1985760411U;
        static const AkUniqueID MUSIC_INVESTIGATE = 1778574366U;
        static const AkUniqueID MUSIC_LEVEL_1 = 3508274217U;
        static const AkUniqueID MUSIC_LEVEL_2 = 3508274218U;
        static const AkUniqueID MUSIC_LEVEL_3 = 3508274219U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace CLOCK_SPEED
        {
            static const AkUniqueID GROUP = 2662357725U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID SPEED_1 = 1590816526U;
                static const AkUniqueID SPEED_2 = 1590816525U;
                static const AkUniqueID SPEED_3 = 1590816524U;
            } // namespace STATE
        } // namespace CLOCK_SPEED

    } // namespace STATES

    namespace SWITCHES
    {
        namespace MUSIC_SWITCH
        {
            static const AkUniqueID GROUP = 2724869341U;

            namespace SWITCH
            {
                static const AkUniqueID INVESTIGATION = 2676391117U;
                static const AkUniqueID NORMAL = 1160234136U;
            } // namespace SWITCH
        } // namespace MUSIC_SWITCH

    } // namespace SWITCHES

    namespace TRIGGERS
    {
        static const AkUniqueID INVESTIGATION = 2676391117U;
    } // namespace TRIGGERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
