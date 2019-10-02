<template>
  <div>
    <table class="table">
      <tr>
        <th></th>
        <th></th>
        <th>Societe Generele</th>
        <th>Customer</th>
      </tr>
      <tr>
        <td>:20</td>
        <td>Our Reference</td>
        <td>{{SGData.ourRef}}</td>
        <td>{{CData.ourRef}}</td>
      </tr>
      <tr>
        <td>:82</td>
        <td>Party A</td>
        <td>{{SGData.PartA}}</td>
        <td>{{CData.PartA}}</td>
      </tr>
      <tr>
        <td>:87</td>
        <td>Party B</td>
        <td>{{SGData.PartB}}</td>
        <td>{{CData.PartB}}</td>
      </tr>
      <tr :class="SGData.ISDADate!=CData.ISDADate?'mismatch':''">
        <td>:77H</td>
        <td>ISDA Date</td>
        <td>{{SGData.ISDADate}}</td>
        <td>{{CData.ISDADate}}</td>
      </tr>
      <tr :class="SGData.ContractDate!=CData.ContractDate?'mismatch':''">
        <td>:30T</td>
        <td>Contract Date</td>
        <td>{{SGData.ContractDate}}</td>
        <td>{{CData.ContractDate}}</td>
      </tr>
      <tr :class="SGData.ValueDate!=CData.ValueDate?'mismatch':''">
        <td>:30V</td>
        <td>Value Date</td>
        <td>{{SGData.ValueDate}}</td>
        <td>{{CData.ValueDate}}</td>
      </tr>
      <tr :class="SGData.ExchangeRate!=CData.ExchangeRate?'mismatch':''">
        <td>:36</td>
        <td>Exchange Rate</td>
        <td>{{SGData.ExchangeRate}}</td>
        <td>{{CData.ExchangeRate}}</td>
      </tr>
      <tr :class="SGData.WeBuy!=CData.WeSell?'mismatch':''">
        <td>:32B - :33B</td>
        <td>We Buy</td>
        <td>{{SGData.WeBuy}}</td>
        <td>{{CData.WeSell}}</td>
      </tr>
      <tr :class="SGData.Intermed1!=CData.Intermed2?'mismatch':''">
        <td>:56</td>
        <td>Intermediary</td>
        <td>{{SGData.Intermed1}}</td>
        <td>{{CData.Intermed2}}</td>
      </tr>
      <tr :class="SGData.Settle1!=CData.Settle2?'mismatch':''">
        <td>:57</td>
        <td>Settlement</td>
        <td>{{SGData.Settle1}}</td>
        <td>{{CData.Settle2}}</td>
      </tr>
      <tr :class="SGData.Ben1!=CData.Ben2?'mismatch':''">
        <td>:58</td>
        <td>Beneficiary</td>
        <td>{{SGData.Ben1}}</td>
        <td>{{CData.Ben2}}</td>
      </tr>
      <button
        v-if="unMatched"
        class="button is-primary forceButton"
        @click="forceMatch()"
      >Force Match</button>
    </table>
  </div>
</template>
<script>
import axios from "axios";
export default {
  props: ["SGData", "CData", "unMatched"],
  data() {
    return {};
  },
  methods: {
    forceMatch() {
      axios
        .get(
          "https://localhost:44311/api/SwiftMatch/forcematch/" +
            this.SGData.ourRef +
            "/" +
            this.CData.ourRef
        )
        .then(function(response) {
          if (response.status == 200) alert("Matched Successfully.");
          //console.log(response);
        });
    }
  }
};
</script>
<style>
.table {
  margin-left: 25%;
}
.tablebackground {
  background-color: white;
}
.mismatch {
  color: red;
}
.forceButton {
  margin-left: 100%;
}
</style>


