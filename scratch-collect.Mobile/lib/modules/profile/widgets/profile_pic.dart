import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:scratch_collect/modules/shared/theme/colors.dart';
import 'package:scratch_collect/modules/shared/theme/size_config.dart';
import 'package:scratch_collect/modules/shared/theme/utils.dart';

class ProfilePic extends StatelessWidget {
  final String? profilePhoto;

  const ProfilePic({Key? key, this.profilePhoto}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return SizedBox(
      height: getProportionateScreenHeight(250),
      width: getProportionateScreenWidth(250),
      child: Stack(
        fit: StackFit.expand,
        clipBehavior: Clip.none,
        children: [
          CircleAvatar(
              backgroundColor: tertiaryColor,
              child: ClipOval(
                  child: Image.memory(base64.decode(profilePhoto ?? "")))),
          Positioned(
            right: 18,
            bottom: 20,
            child: SizedBox(
              height: 64,
              width: 64,
              child: TextButton(
                style: TextButton.styleFrom(
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(50),
                    side: const BorderSide(color: whiteColor),
                  ),
                  primary: whiteColor,
                  backgroundColor: const Color(0xFFF5F6F9),
                ),
                onPressed: () {},
                child: SvgPicture.asset(
                    "lib/modules/shared/assets/icons/camera.svg",
                    color: primaryColor),
              ),
            ),
          )
        ],
      ),
    );
  }
}
