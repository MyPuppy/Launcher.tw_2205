using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KartRider.IO;
using System.Net;
using Set_Data;

namespace KartRider
{
    public static class GameSupport
    {
        public static void PcFirstMessage()
        {
            uint first_val = 3059596768;
            uint second_val = 1772034572;
            using (OutPacket outPacket = new OutPacket("PcFirstMessage"))
            {
                outPacket.WriteUShort(SessionGroup.usLocale);
                outPacket.WriteUShort(1);
                outPacket.WriteUShort(Program.Version);
                outPacket.WriteString("http://tw.cdnpatch.kartrider.beanfun.com/kartrider/");
                outPacket.WriteUInt(first_val);
                outPacket.WriteUInt(second_val);
                outPacket.WriteByte(SessionGroup.nClientLoc);
                outPacket.WriteString("DI5gSCYZrEcZjR4fma5gSevvLBGSzKMoOPl7ZHDmfgA=");
                outPacket.WriteHexString("00 00 00 00 00 00 00 00 01 00 01 00 00 00 00 00 B0 49 51 19 00 00 00 00 08 C0 70 0E 00 00 00");
                outPacket.WriteString("bLV2VEcHkS8SrZVuPwitWN+I2851xwVEr+UBEzcYz+8=");
                RouterListener.MySession.Client.Send(outPacket);
            }
            RouterListener.MySession.Client._RIV = first_val ^ second_val;
            RouterListener.MySession.Client._SIV = first_val ^ second_val;
        }

        public static void OnDisconnect()
        {
            RouterListener.MySession.Client.Disconnect();
        }

        public static void SpRpLotteryPacket()
        {
            using (OutPacket outPacket = new OutPacket("SpRpLotteryPacket"))
            {
                outPacket.WriteHexString("05 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00");
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrGetGameOption()
        {
            using (OutPacket outPacket = new OutPacket("PrGetGameOption"))
            {
                outPacket.WriteFloat(SetGameOption.Set_BGM);
                outPacket.WriteFloat(SetGameOption.Set_Sound);
                outPacket.WriteByte(SetGameOption.Main_BGM);
                outPacket.WriteByte(SetGameOption.Sound_effect);
                outPacket.WriteByte(SetGameOption.Full_screen);
                outPacket.WriteByte(SetGameOption.Unk1);
                outPacket.WriteByte(SetGameOption.Unk2);
                outPacket.WriteByte(SetGameOption.Unk3);
                outPacket.WriteByte(SetGameOption.Unk4);
                outPacket.WriteByte(SetGameOption.Unk5);
                outPacket.WriteByte(SetGameOption.Unk6);
                outPacket.WriteByte(SetGameOption.Unk7);
                outPacket.WriteByte(SetGameOption.Unk8);
                outPacket.WriteByte(SetGameOption.Unk9);
                outPacket.WriteByte(SetGameOption.Unk10);
                outPacket.WriteByte(SetGameOption.Unk11);
                outPacket.WriteByte(SetGameOption.BGM_Check);
                outPacket.WriteByte(SetGameOption.Sound_Check);
                outPacket.WriteByte(SetGameOption.Unk12);
                outPacket.WriteByte(SetGameOption.Unk13);
                outPacket.WriteByte(SetGameOption.GameType);
                outPacket.WriteByte(SetGameOption.SetGhost);
                outPacket.WriteByte(SetGameOption.SpeedType);
                outPacket.WriteByte(SetGameOption.Unk14);
                outPacket.WriteByte(SetGameOption.Unk15);
                outPacket.WriteByte(SetGameOption.Unk16);
                outPacket.WriteBytes(new byte[40]);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void ChRpEnterMyRoomPacket()
        {
            if (GameType.EnterMyRoomType == 0)
            {
                using (OutPacket outPacket = new OutPacket("ChRpEnterMyRoomPacket"))
                {
                    outPacket.WriteString(SetRider.Nickname);
                    outPacket.WriteByte(0);
                    outPacket.WriteShort(SetMyRoom.MyRoom);
                    outPacket.WriteByte(SetMyRoom.MyRoomBGM);
                    outPacket.WriteByte(SetMyRoom.UseRoomPwd);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(SetMyRoom.UseItemPwd);
                    outPacket.WriteByte(SetMyRoom.TalkLock);
                    outPacket.WriteString(SetMyRoom.RoomPwd);
                    outPacket.WriteString("");
                    outPacket.WriteString(SetMyRoom.ItemPwd);
                    outPacket.WriteShort(SetMyRoom.MyRoomKart1);
                    outPacket.WriteShort(SetMyRoom.MyRoomKart2);
                    RouterListener.MySession.Client.Send(outPacket);
                }
            }
            else
            {
                using (OutPacket outPacket = new OutPacket("ChRpEnterMyRoomPacket"))
                {
                    outPacket.WriteString("");
                    outPacket.WriteByte(GameType.EnterMyRoomType);
                    outPacket.WriteShort(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(1);
                    outPacket.WriteString("");//RoomPwd
                    outPacket.WriteString("");
                    outPacket.WriteString("");//ItemPwd 
                    outPacket.WriteShort(0);
                    outPacket.WriteShort(0);
                    RouterListener.MySession.Client.Send(outPacket);
                }
            }
        }

        public static void RmNotiMyRoomInfoPacket()
        {
            using (OutPacket outPacket = new OutPacket("RmNotiMyRoomInfoPacket"))
            {
                outPacket.WriteShort(SetMyRoom.MyRoom);
                outPacket.WriteByte(SetMyRoom.MyRoomBGM);
                outPacket.WriteByte(SetMyRoom.UseRoomPwd);
                outPacket.WriteByte(0);
                outPacket.WriteByte(SetMyRoom.UseItemPwd);
                outPacket.WriteByte(SetMyRoom.TalkLock);
                outPacket.WriteString(SetMyRoom.RoomPwd);
                outPacket.WriteString("");
                outPacket.WriteString(SetMyRoom.ItemPwd);
                outPacket.WriteShort(SetMyRoom.MyRoomKart1);
                outPacket.WriteShort(SetMyRoom.MyRoomKart2);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrGetRiderInfo()
        {
            using (OutPacket outPacket = new OutPacket("PrGetRiderInfo"))
            {
                outPacket.WriteByte(1);
                outPacket.WriteUInt(SetRider.UserNO);
                outPacket.WriteString(SetRider.UserID);
                outPacket.WriteString(SetRider.Nickname);
                outPacket.WriteHexString("3C 9A 17 43");//2008.02.08
                for (int i = 1; i <= Program.MAX_EQP_P; i++)
                {
                    outPacket.WriteShort(0);
                }
                outPacket.WriteByte(0);
                outPacket.WriteString("");
                outPacket.WriteInt(SetRider.RP);
                outPacket.WriteInt(0);
                outPacket.WriteByte(6);//Licenses
                outPacket.WriteHexString(Program.DataTime);
                outPacket.WriteBytes(new byte[16]);
                outPacket.WriteShort(SetRider.Emblem1);
                outPacket.WriteShort(SetRider.Emblem2);
                outPacket.WriteShort(0);
                outPacket.WriteString(SetRider.RiderIntro);
                outPacket.WriteInt(SetRider.Premium);
                outPacket.WriteByte(1);
                if (SetRider.Premium == 0)
                    outPacket.WriteInt(0);
                else if (SetRider.Premium == 1)
                    outPacket.WriteInt(10000);
                else if (SetRider.Premium == 2)
                    outPacket.WriteInt(30000);
                else if (SetRider.Premium == 3)
                    outPacket.WriteInt(60000);
                else if (SetRider.Premium == 4)
                    outPacket.WriteInt(120000);
                else if (SetRider.Premium == 5)
                    outPacket.WriteInt(200000);
                else
                    outPacket.WriteInt(0);
                if (SetRider.ClubMark_LOGO == 0)
                {
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteString("");
                }
                else
                {
                    outPacket.WriteInt(SetRider.ClubCode);
                    outPacket.WriteInt(SetRider.ClubMark_LOGO);
                    outPacket.WriteString(SetRider.ClubName);
                }
                outPacket.WriteInt(0);
                outPacket.WriteByte(SetRider.Ranker);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                outPacket.WriteByte(0);
                outPacket.WriteByte(0);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrCheckMyClubStatePacket()
        {
            using (OutPacket outPacket = new OutPacket("PrCheckMyClubStatePacket"))
            {
                if (SetRider.ClubMark_LOGO == 0)
                {
                    outPacket.WriteInt(0);
                    outPacket.WriteString("");
                    outPacket.WriteInt(0);
                }
                else
                {
                    outPacket.WriteInt(SetRider.ClubCode);
                    outPacket.WriteString(SetRider.ClubName);
                    outPacket.WriteInt(SetRider.ClubMark_LOGO);
                }
                outPacket.WriteShort(5);//Grade
                outPacket.WriteString(SetRider.Nickname);
                outPacket.WriteInt(1);//ClubMember
                outPacket.WriteByte(5);//Level
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void ChRequestChStaticReplyPacket()
        {
            using (OutPacket outPacket = new OutPacket("ChRequestChStaticReplyPacket"))
            {
                outPacket.WriteHexString("01 73 02 00 00 53 01 27 DB 2E DA 08 0B 00 00 78 DA 9D 55 5D 57 DA 40 10 BD 15 11 FC 80 44 23 28 D6 56 FB 5D 5B B5 B5 FF 40 1E DA E3 43 FB 50 FB DE A3 80 96 23 15 0E 84 DA 9F EF 9D 8D 2B 09 0C D9 C0 C9 39 9B 64 F6 CE 9D 99 DD D9 BD 27 00 96 97 39 0C D0 43 8B 4F 13 67 B8 E5 D8 C6 82 47 73 1B 21 8D 7F F1 83 E3 1D A7 A2 BF 5F 1C 2F F8 CE 4D 87 58 96 C5 C0 C9 F2 95 E3 80 B6 7C E0 64 B3 D0 A5 8A 93 35 B2 5E 12 D5 42 A1 E2 64 8E C3 8B C9 05 B1 8C 2B 25 D5 6C 73 5A 2D A9 CB 68 A7 D7 FC 54 EF 96 19 4B 7E 2A 47 04 2A 7B 2A 53 BC 02 CF 53 79 E2 10 5F 42 5D 63 C8 9F 8E 99 D4 56 67 7D 25 01 1A 31 6E 2C 71 E2 92 71 43 3E 1D 9A 82 22 0D 57 FC BC 20 DE A6 B4 19 37 DA 24 2A 7A 8D F2 BE E2 FB D6 A4 52 D5 57 2B 09 DA 2A 9B EC FA 9C 12 8E 1E BF DA F8 8F DF 8F C5 6C 07 53 00 93 E1 6B 35 07 97 DE 36 3B 3B 99 23 24 73 7F BA 6D 16 B0 8B 1B 8E 43 2E 51 F4 7D 96 1A 6D 77 43 75 3A 9F 88 F5 AC 96 11 98 4C EA B9 DE 36 E7 F8 C3 FA 9A A4 B8 C3 5E D5 09 49 72 EE 57 D5 9D 9C EE F0 A2 40 87 8E A9 DC B2 BF 1C 99 AC FF 2B FD B4 7D 33 1B D0 C3 6B FD AC DA E9 37 6B B1 0B E1 FB 43 68 CB F1 56 9B B4 0C EF A4 9C D0 9C A0 3E 27 E5 00 34 58 8A 80 AE D5 6D 7F 9F D5 C1 46 38 D8 4D 75 48 EF C7 0F F3 38 DB C8 1F 25 D5 7F C6 75 C0 AE 19 90 A0 4B D6 96 71 D4 6E A2 C3 45 3A 34 B8 33 43 36 D8 51 39 F6 F3 93 B8 86 F1 1C 15 78 5C 52 01 36 A7 4F D2 7C 7D 46 94 B6 A8 13 D6 25 E0 26 C1 F0 59 42 34 4D B6 21 AB 1A D5 67 2B 38 89 1A 38 34 BF 1D 03 1A 5F A1 2F FE 04 64 F2 58 6C 11 F3 04 6E 01 5C 80 E8 27 66 53 23 B9 3A E9 E9 D6 CE 9C 00 73 C8 AE A0 B2 1D 1C B2 EB 68 5E 1C F2 48 17 36 D1 00 26 9D 2E 6F AB 02 2A 20 8B C8 C9 F1 42 11 59 A4 4E 62 32 FE 6C F2 2D 97 05 F3 71 AB A4 74 13 B3 71 6B A5 20 98 4B BC DB 0F C5 54 86 AB E7 8F 04 E6 21 BD F3 8F 05 E4 63 5C 52 E5 B2 C7 3A 1F B7 5C 9E 9A 25 A2 47 16 70 3D 02 07 63 60 5D 63 4F 21 97 02 36 33 81 EB 11 B8 82 59 45 62 4F DC AA 98 57 4C C5 8F 67 76 3E 09 17 2F DC 03 E5 36 DB 28");
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrDynamicCommand()
        {
            using (OutPacket outPacket = new OutPacket("PrDynamicCommand"))
            {
                outPacket.WriteByte(0);
                outPacket.WriteInt(0);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrQuestUX2ndPacket()
        {
            //questGroupIndex='2' seasonId='17' kartPassSetId='1' unk='0' id='13'
            //EX) 217010013
            int NormalQuest = 8;
            int KartPassQuest = 13;
            int All_Quest = NormalQuest + KartPassQuest;
            using (OutPacket outPacket = new OutPacket("PrQuestUX2ndPacket"))
            {
                outPacket.WriteInt(1);
                outPacket.WriteInt(1);
                outPacket.WriteInt(All_Quest);
                for (int i = 981; i <= 988; i++)
                {
                    outPacket.WriteInt(i);
                    outPacket.WriteInt(i);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(2);
                    outPacket.WriteInt(0);
                    outPacket.WriteByte(0);
                }
                //questGroupIndex='1'
                outPacket.WriteInt(103004301);
                outPacket.WriteInt(103004301);
                outPacket.WriteHexString("00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00");
                outPacket.WriteInt(103004302);
                outPacket.WriteInt(103004302);
                outPacket.WriteHexString("00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00");
                outPacket.WriteInt(103004303);
                outPacket.WriteInt(103004303);
                outPacket.WriteHexString("00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00");
                //questGroupIndex = '2'
                outPacket.WriteInt(203010001);
                outPacket.WriteInt(203010001);
                outPacket.WriteHexString("00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00");
                outPacket.WriteInt(203020001);
                outPacket.WriteInt(203020001);
                outPacket.WriteHexString("00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00");
                outPacket.WriteInt(203030001);
                outPacket.WriteInt(203030021);
                outPacket.WriteHexString("00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00");
                outPacket.WriteInt(203040001);
                outPacket.WriteInt(203040001);
                outPacket.WriteHexString("00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00");
                //questGroupIndex='3'
                outPacket.WriteInt(303010001);
                outPacket.WriteInt(303010001);
                outPacket.WriteHexString("00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00");
                outPacket.WriteInt(303020001);
                outPacket.WriteInt(303020001);
                outPacket.WriteHexString("00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00");
                outPacket.WriteInt(303030001);
                outPacket.WriteInt(303030001);
                outPacket.WriteHexString("00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00");
                outPacket.WriteInt(303040001);
                outPacket.WriteInt(303040001);
                outPacket.WriteHexString("00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00");
                outPacket.WriteInt(303050001);
                outPacket.WriteInt(303050001);
                outPacket.WriteHexString("00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00");
                outPacket.WriteInt(303060001);
                outPacket.WriteInt(303060001);
                outPacket.WriteHexString("00 00 00 00 FF FF 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00");
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrLogin()
        {
            using (OutPacket outPacket = new OutPacket("PrLogin"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteHexString(Program.DataTime);
                outPacket.WriteUInt(SetRider.UserNO);
                outPacket.WriteString(SetRider.UserID);
                outPacket.WriteByte(2);
                outPacket.WriteByte(1);
                outPacket.WriteByte(0);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                outPacket.WriteInt(1415577599);
                outPacket.WriteUInt(SetRider.pmap);
                for (int i = 0; i < 11; i++)
                {
                    outPacket.WriteInt(0);
                }
                outPacket.WriteByte(0);
                outPacket.WriteEndPoint(IPAddress.Parse(RouterListener.forceConnect), 39311);
                outPacket.WriteEndPoint(IPAddress.Parse(RouterListener.forceConnect), 39312);
                outPacket.WriteInt(0);
                outPacket.WriteString("");
                outPacket.WriteInt(0);
                outPacket.WriteByte(1);
                outPacket.WriteString("content");
                outPacket.WriteInt(0);
                outPacket.WriteInt(1);
                outPacket.WriteString("cc");
                outPacket.WriteString(SessionGroup.Service);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }
    }
}