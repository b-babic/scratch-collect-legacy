class UseVoucherRequest {
  String? userId;
  String? walletId;
  String? coupon;

  UseVoucherRequest({
    this.userId,
    this.walletId,
    this.coupon,
  });

  UseVoucherRequest.fromJson(Map<String, dynamic> json) {
    userId = json['userId'];
    walletId = json['walletId'];
    coupon = json['coupon'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['userId'] = userId;
    data['walletId'] = walletId;
    data['coupon'] = coupon;

    return data;
  }
}
