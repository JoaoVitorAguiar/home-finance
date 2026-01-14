export function formatCurrency(
    value: number,
    locale: string = "en-US",
    currency: string = "USD"
) {
    return new Intl.NumberFormat(locale, {
        style: "currency",
        currency,
    }).format(value)
}

export function formatDateTime(
    iso?: string,
    locale: string = "en-US"
) {
    if (!iso) return "-"

    const d = new Date(iso)

    return d.toLocaleString(locale, {
        dateStyle: "short",
        timeStyle: "short",
    })
}