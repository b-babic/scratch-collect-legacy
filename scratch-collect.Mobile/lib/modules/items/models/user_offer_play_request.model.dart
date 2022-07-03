class UserOfferPlayRequest {
  int? userOfferId;
  int? offerId;
  bool? won;

  UserOfferPlayRequest(
    this.userOfferId,
    this.offerId,
    this.won,
  );

  UserOfferPlayRequest.fromJson(Map<String, dynamic> json) {
    userOfferId = json['userId'];
    offerId = json['offerId'];
    won = json['won'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['userOfferId'] = userOfferId;
    data['offerId'] = offerId;
    data['won'] = won;

    return data;
  }
}
