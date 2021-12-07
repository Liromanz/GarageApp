package com.example.test.model

import com.google.gson.annotations.SerializedName

data class history(
    @SerializedName("id") var id:Int,
    @SerializedName("idUser") var idUser:Int,
    @SerializedName("datePass") var datePass: String)