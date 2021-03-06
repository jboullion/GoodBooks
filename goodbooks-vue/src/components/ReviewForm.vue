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
            v-model="review.reviewRating"
            background-color="orange lighten-3"
            color="orange"
            large
        ></v-rating>

        <v-text-field
            v-model="review.reviewAuthor"
            label="Author"
            required
        ></v-text-field>

        <v-textarea
            v-model="review.reviewContent"
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
import { Component, Prop, Vue } from 'vue-property-decorator';

const reviewService = new ReviewService();

@Component({
    name: 'AddReview',
    components: { }
})
export default class AddReview extends Vue {
    // data
    review: IReview = {
        reviewContent: '',
        reviewAuthor: '',
        reviewRating: 3,
        bookId: 0
    };

    @Prop({ required: true })
    bookId!: number;

    created() {
        this.review.bookId = this.bookId;
    }

    reset () {
        //this.$refs.form.reset();
        this.review.reviewContent = '';
        this.review.reviewAuthor = '';
        this.review.reviewRating = 3;
    }

    get isButtonDisabled(){
        return this.review.reviewContent === "" 
        || this.review.reviewAuthor === "";
    }

    submitReview(){
        reviewService.addBookReview(this.review)
            .then(() => {
                //console.log(res);
                this.reset();
                this.$emit('reloadReviews');
            })
            .catch(err => console.error(err));
        
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
