import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';

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
            child: SizedBox.expand(
              child: ClipOval(
                child: Image.memory(
                  base64.decode(profilePhoto ?? ""),
                  fit: BoxFit.cover,
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
