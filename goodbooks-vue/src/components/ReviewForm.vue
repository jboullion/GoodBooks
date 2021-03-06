<template>
    <v-card
    class="mx-auto"
    elevation="2"
    ><v-card-text>
        <v-form
            ref="form"
            lazy-validation
        >

        <v-rating
            v-model="review.rating"
            background-color="orange lighten-3"
            color="orange"
            large
        ></v-rating>

        <v-text-field
            v-model="review.author"
            label="Author"
            required
        ></v-text-field>

        <v-textarea
            v-model="review.content"
            label="Content"
            hint="How did this book make you feel?"
            class="mb-4"
        ></v-textarea>

        <v-btn
            :disabled="isButtonDisabled"
            color="success"
            class="mr-4"
            @click="submitReview"
        >
            Submit
        </v-btn>

        <v-btn
            color="error"
            class="mr-4"
            @click="reset"
        >
            Reset Form
        </v-btn>
        </v-form>
        </v-card-text>
    </v-card>
</template>

<script lang="ts">
import ReviewService from "@/services/review-service";
import IReview from '@/types/Review';
import { Component, Vue } from 'vue-property-decorator';

const reviewService = new ReviewService();

@Component({
    name: 'AddReview',
    components: { }
})
export default class AddReview extends Vue {
    // data
    review: IReview = {
        content: '',
        author: '',
        rating: 3
    };

    valid = false;

    reset () {
        //this.$refs.form.reset();
        this.review.content = '';
        this.review.author = '';
        this.review.rating = 3;
    }

    get isButtonDisabled(){
        return this.review.content === "" 
        || this.review.author === "";
    }

    submitReview(){
        console.log(this.review);

        // reviewService.addBookReview(this.review)
        //     .then(() => {
        //     //console.log(res);
        //     this.reset();
        //     })
        //     .catch(err => console.error(err));
        
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
